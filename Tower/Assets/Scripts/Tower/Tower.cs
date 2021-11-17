using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private GameObject _towerPlace; 

    public GameObject bullet;

    Enemies enemy;
    Transform towerHead;
    private float FindRadius = 2f;
    private float TimeShoot = 0.8f;
    private float timerShoot = 1f;
    private GameObject _forTrashContainer;
    private string _headTowerObjectName = "Head";


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

            // пулю сразу инстантиируем в мусорном контейнере _forTrashContainer
            GameObject bulletAfterShoot = Instantiate(bullet, towerHead.transform.position, towerHead.transform.rotation, _forTrashContainer.transform);

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
            // поиск врага
            FindEnemy();
        }
        else
        {
            // вращение башни в направлении врага
            towerHead.LookAt(enemy.transform);

            // выстрел
            Shoot();

            float dist = Vector3.Distance(enemy.transform.position, transform.position);

            if(dist>FindRadius)
            {
                enemy = null;
            }
        }

        // самоуничтожение, если игра остановилась!
        if (GameController.Instance.AreGameIsStarting() == false)
        {
            Instantiate(_towerPlace, gameObject.transform);
            Destroy(gameObject);
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
        // была задумка сделать анимацию радости, что когда враг убит - все башни радуются
    }




}
