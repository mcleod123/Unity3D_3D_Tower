using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{

    bool isCanBuild = true;
    public GameObject tower;
    CoinsController coinsController;


    private Color _emptyColor = SettingsController.EmptyTowerPlaceColor;
    private Color _selectionColor = SettingsController.SelectionTowerPlaceColor;
    private Color _deleteColor = SettingsController.DeleteTowerPlaceColor;

    private int _towerBuildingCost = SettingsController.TowerBuildingCost;

    private void Awake()
    {
        coinsController = CoinsController.Instance;
    }


    public void OnMouseDown()
    {
        if(GameController.Instance.AreGameIsStarting() == true)
        {
            BuildTheTower();
        }
 
    }

    public void OnMouseUp()
    {
        
    }

    public void OnMouseEnter()
    {
        if(isCanBuild)
        {
            // GetComponent<Renderer>().material.color = _selectionColor;
        }
    }

    public void OnMouseExit()
    {
        if(isCanBuild)
        {
            //GetComponent<Renderer>().material.color = _emptyColor;
        }
    }




    public void BuildTheTower()
    {
        if (coinsController == null)
        {
            coinsController = CoinsController.Instance;
        }

        // если не хватает на постройку
        if (!coinsController.AreWeCanBuildBuildings(_towerBuildingCost))
        {
            isCanBuild = false;
        }
        else
        {
            isCanBuild = true;
        }



        if (isCanBuild)
        {
            isCanBuild = false;
            Instantiate(tower, transform.position, transform.rotation);
            //GetComponent<Renderer>().material.color = _emptyColor;

            // событие постройки башни
            var eventData = new TowerBuildingEventData() { TowerTypeData = TowerType.Duck, TowerBuildingCost = _towerBuildingCost };
            EventAggregator.Post(this, eventData);

            // звук постройки башни
            AudioManager.PlaySFX(SFXType.TowerBuildComplete);

            // удалим клетку
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }




}
