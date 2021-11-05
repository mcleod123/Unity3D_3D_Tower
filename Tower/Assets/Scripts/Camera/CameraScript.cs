using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    private Camera camera;
    private TowerPlace currentTowerPlace;

    private string _towerPlaceTagName = "TowerPlace";
    private string _towerTagName = "TowerRoof";


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameController.Instance.AreGameIsStarting() == true)
        {
            BuildTheTowers();
        }


    }


    private void BuildTheTowers()
    {

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



        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == _towerTagName)
        {
            // ===========
            // Right Click
            // ===========

            //Debug.Log("Нажали по башне утке, чтобы ее улучшить");
            //Debug.Log(hit.collider.gameObject.tag.ToString());

                bool isMouseRightDown = Input.GetMouseButtonDown(1);
                bool isMouseRightUp = Input.GetMouseButtonUp(1);

            Tower tower = hit.collider.gameObject.GetComponent<Tower>();

            if (isMouseRightDown || isMouseRightUp)
            {
                    if (isMouseRightDown)
                    {
                    // tower.OnMouseRightDown();
                    
                    }
                    else if (isMouseRightUp)
                    {
                        Debug.Log("Нажали по башне утке, чтобы ее улучшить");
                    Destroy(tower);
                    // tower.OnMouseRightUp();
                }
            }

            // ===========       
        }


    }


}
