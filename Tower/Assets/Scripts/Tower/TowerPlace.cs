using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{

    bool isCanBuild = true;
    public GameObject tower;
    CoinsController coinsController;

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

            // событие постройки башни
            var eventData = new TowerBuildingEventData() { TowerTypeData = TowerType.Duck, TowerBuildingCost = _towerBuildingCost };
            EventAggregator.Post(this, eventData);

            // звук постройки башни
            AudioManager.PlaySFX(SFXType.TowerBuildComplete);

            // скроем клетку
            gameObject.SetActive(false);

        }
    }

    public void OnMouseUp()
    {

    }

    public void OnMouseEnter()
    {

    }

    public void OnMouseExit()
    {

    }


}
