using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Camera camera;
    private TowerPlace currentTowerPlace;

    private string _towerPlaceTagName = "TowerPlace";

    void Start()
    {
        camera = GetComponent<Camera>();
    }


    void Update()
    {
        // если игра уже идет, то имеем возможность строить башни
        if (GameController.Instance.AreGameIsStarting() == true)
        {
            BuildTheTowers();
        }
    }


    private void BuildTheTowers()
    {

        // надо определить, куда именно мы тыкнули, чтобы поставить там башню
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == _towerPlaceTagName)
        {

            bool isMouseDown = Input.GetMouseButtonDown(0);
            bool isMouseUp = Input.GetMouseButtonUp(0);

            TowerPlace towerPlace = hit.collider.gameObject.GetComponent<TowerPlace>();

            if (isMouseDown || isMouseUp)
            {
 
                if(isMouseDown)
                {
                    towerPlace.OnMouseDown();
                } 
                else if (isMouseUp)
                {
                    towerPlace.OnMouseUp();
                }
            } 
            else
            {
                if (currentTowerPlace != towerPlace)
                {
                    if (currentTowerPlace!=null)
                    {
                        currentTowerPlace.OnMouseExit();
                    }

                    towerPlace.OnMouseEnter();
                    currentTowerPlace = towerPlace;
                }

            }


        }
        else
        {
            if (currentTowerPlace != null)
            {
                currentTowerPlace.OnMouseExit();
            }

            currentTowerPlace = null;
        }


    }

}
