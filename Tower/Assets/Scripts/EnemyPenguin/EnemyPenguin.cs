using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPenguin : Enemies
{
    [SerializeField] private GameObject _enemyPenguineDiedEffect;
    [SerializeField] private GameObject _enemyPenguineBody;

    //private int EnemyPenguineDeathCost = SettingsController.EnemyDeathCost;
    private int EnemyPenguineDeathCost = 50;
    private GameObject _forTrashContainer;

    private Transform waypoints;
    private Transform waypoint;
    private Quaternion _quaternionRotation;
    private int waypointIndex = -1;
    private float life;
    private float speed = 0.3f;
    private float MaxLife = 500f;

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

        float _speed = Time.deltaTime * speed;
        transform.Translate(enemyMoveDirection.normalized * _speed);

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

        if (waypoint != null)
        {
            _quaternionRotation = waypoint.transform.rotation;
            _enemyPenguineBody.transform.localRotation = _quaternionRotation;
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

        AudioManager.PlaySFX(SFXType.MetalBulletHit);


        life -= value;
        if (life <= nullLife)
        {

            // событие смерти врага, которое принесет нам денежек на счет
            var eventData = new EnemyDeathEventData() { Enemy = EnemyType.EnemyPenguine, EnemyDeathCost = EnemyPenguineDeathCost };
            EventAggregator.Post(this, eventData);

            // звук - убили врага
            AudioManager.PlaySFX(SFXType.EnemyCatDied);

            // _enemyCatDiedEffect
            //GameObject effectGameObjectToDestroy = Instantiate(_enemyCatDiedEffect, transform.position, transform.rotation);
            GameObject effectGameObjectToDestroy = Instantiate(_enemyPenguineDiedEffect, transform.position, transform.rotation, _forTrashContainer.transform);
            //StartCoroutine(DestroyEffectObject(effectGameObjectToDestroy));

            // убили обьект
            Destroy(gameObject);

            // удаляем эффект уничтожения
            Destroy(effectGameObjectToDestroy, _enemyDieEffectIntervalDissaopear);


        }
    }



}
