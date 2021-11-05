using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;

    Enemies enemy;
    Transform towerHead;
    private float FindRadius = 2f;
    private float TimeShoot = 0.8f;
    private float timerShoot = 1f;
    private GameObject _forTrashContainer;
    private string _headTowerObjectName = "Head";

    // Start is called before the first frame update
    void Start()
    {
        towerHead = transform.Find(_headTowerObjectName);
        _forTrashContainer = GameObject.Find(SettingsController.TrashContainerObjectName);
    }


    private void Shoot() 
    {
        timerShoot -= Time.deltaTime;

        if(timerShoot <= 0)
        {
            timerShoot = TimeShoot;

            // 
            // GameObject bulletAfterShoot = Instantiate(bullet, towerHead.transform.position, towerHead.transform.rotation);
            GameObject bulletAfterShoot = Instantiate(bullet, towerHead.transform.position, towerHead.transform.rotation, _forTrashContainer.transform);
            // GameObject bulletAfterShoot = Instantiate(bullet, transform.position, transform.rotation, GameObject.Find(_shootObjectName).transform);



            Bullet b = bulletAfterShoot.GetComponent<Bullet>();
            b.Enemy = enemy;

            AudioManager.PlaySFX(SFXType.Shoot);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
        {
            // find enemies
            FindEnemy();
        }
        else
        {
            // rotate dule
            towerHead.LookAt(enemy.transform);

            // shoot
            Shoot();

            float dist = Vector3.Distance(enemy.transform.position, transform.position);

            if(dist>FindRadius)
            {
                enemy = null;
            }
        }
    }

    private void FindEnemy()
    {
        var enemies = GameObject.FindObjectsOfType<Enemies>();

        float min = FindRadius;
        Enemies minEnemy = null;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);

            if( dist <= min)
            {
                min = dist;
                minEnemy = e;
            }
        }

        enemy = minEnemy;

    }





    void Awake()
    {
        // подписка на событие - смерть врага
        EventAggregator.Subscribe<EnemyDeathEventData>(OnEnemyDeathEventHandler);
    }

    private void OnDestroy()
    {
        // отписка от события - смерть врага
        EventAggregator.Unsubscribe<EnemyDeathEventData>(OnEnemyDeathEventHandler);
    }




    private void OnEnemyDeathEventHandler(object sender, EnemyDeathEventData eventData)
    {
        // Debug.Log("Башня радуется что кого-то убила! Это: " + eventData.Enemy + " Очки: " + eventData.EnemyDeathCost );
    }




    // --------------------------
    public void OnMouseRightDown()
    {
        Debug.Log("OnMouseRightDown");
        //GetComponent<Renderer>().material.color = _deleteColor;
    }

    public void OnMouseRightUp()
    {
        Debug.Log("OnMouseRightUp");
        //GetComponent<Renderer>().material.color = _deleteColor;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            print(hit.transform.name);
        }

    }






}
