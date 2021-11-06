using System.Collections;
using UnityEngine;



public class Enemy : Enemies
{

    [SerializeField] private GameObject _enemyCatDiedEffect;
    [SerializeField] private GameObject _enemyBody;

    private int EnemyDeathCost = SettingsController.EnemyDeathCost;
    private GameObject _forTrashContainer;

    private Transform waypoints;
    private Transform waypoint;
    private Quaternion _quaternionRotation;
    private int waypointIndex = -1;
    private float life;
    private float speed = SettingsController.EnemyMovingSpeed;
    private float MaxLife = SettingsController.EnemyMaxLife;

    private float nullLife = 0;
    private int freezeCoordY = 0;
    private string _wayPointsGroup = SettingsController.EnemyWayPointsGroup;
    private float _enemyDieEffectIntervalDissaopear = SettingsController.EnemyDieEffectIntervalDissapear;

    void Start()
    {
        // waypoints = GameObject.Find("WayPoints").transform;
        waypoints = GameObject.Find(_wayPointsGroup).transform;
        _forTrashContainer = GameObject.Find(SettingsController.TrashContainerObjectName);
        NextWaypoint();
        life = MaxLife;
    }

    void Update()
    {
        Vector3 enemyMoveDirection = waypoint.transform.position - transform.position;
        enemyMoveDirection.y = freezeCoordY;

        // ===========
        //Quaternion enemyRotation = waypoint.transform.rotation;
        // ===========

        float _speed = Time.deltaTime * speed;
        transform.Translate(enemyMoveDirection.normalized * _speed);
        //transform.TransformDirection(enemyMoveDirection);



        // ------------------------------------
        // gameObject.transform.rotation = new Quaternion(enemyMoveDirection.x, freezeCoordY, enemyMoveDirection.z, 1);
        // transform.rotation = Quaternion.Euler(enemyMoveDirection.x, enemyMoveDirection.x * enemyMoveDirection.y, enemyMoveDirection.z);
        //transform.rotation = Quaternion.Euler(enemyMoveDirection.x, enemyMoveDirection.x * enemyMoveDirection.y, enemyMoveDirection.z);





        if (enemyMoveDirection.magnitude <= _speed)
        {
            NextWaypoint();
        }



        // самоуничтожение, если игра остановилась!
        if (GameController.Instance.AreGameIsStarting() == false)
        {
            Destroy(gameObject);
        }



    }









    void NextWaypoint()
    {

        if(waypoint != null)
        {
            _quaternionRotation = waypoint.transform.rotation;
            _enemyBody.transform.localRotation = _quaternionRotation;
        }


        waypointIndex++;
        if (waypointIndex >= waypoints.childCount)
        {

            // событие при котором враг доходит до финиша и забирает жизнь игрока
            var eventData = new EnemyWasMovedToFinish() { Enemy = EnemyType.EnemyCat };
            EventAggregator.Post(this, eventData);


            Destroy(gameObject);
            return;
        }



        waypoint = waypoints.GetChild(waypointIndex);



    }

    public override void SetDamage(float value)
    {
        life -= value;
        if(life <= nullLife)
        {

            // событие смерти врага, которое принесет нам денежек на счет
            var eventData = new EnemyDeathEventData() { Enemy = EnemyType.EnemyCat, EnemyDeathCost = EnemyDeathCost };
            EventAggregator.Post(this, eventData);

            // звук - убили врага котика
            AudioManager.PlaySFX(SFXType.EnemyCatDied);

            // _enemyCatDiedEffect
            //GameObject effectGameObjectToDestroy = Instantiate(_enemyCatDiedEffect, transform.position, transform.rotation);
            GameObject effectGameObjectToDestroy = Instantiate(_enemyCatDiedEffect, transform.position, transform.rotation, _forTrashContainer.transform);
            //StartCoroutine(DestroyEffectObject(effectGameObjectToDestroy));

            // убили обьект
            Destroy(gameObject);

            // удаляем эффект уничтожения котика
            Destroy(effectGameObjectToDestroy, _enemyDieEffectIntervalDissaopear);


        }
    }





}