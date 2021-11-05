using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{



    // кого мы спауним
    [SerializeField] private GameObject _enemyPrefabItem;
    [SerializeField] private GameObject _enemyJetPlane;

    // задержка перед рождением объекта
    private float spawnTime = 5f;

    // задержка перед началом волны
    private float _spawnEnemyItemsInterval = SettingsController.SpawnEnemyItemsInterval;

    private string _spawnObjectName = "Spawner";



    // Update is called once per frame
    void Update()
    {

        if(GameController.Instance.AreGameIsStarting() == true)
        {
            GenerateEnemies();
        }

    }



    private void GenerateEnemies()
    {

        _spawnEnemyItemsInterval -= Time.deltaTime;

        if (_spawnEnemyItemsInterval <= 0)
        {
            Instantiate(_enemyPrefabItem, transform.position, transform.rotation, GameObject.Find(_spawnObjectName).transform);
            _spawnEnemyItemsInterval = spawnTime;
        }

        //_spawnEnemyItemsInterval = SettingsController.SpawnEnemyItemsInterval;
    }


    private void Awake()
    {
        // подписка на событие - смерть врага
        EventAggregator.Subscribe<GameIsStarted>(OnGameIsStartedEventHandler);
    }

    private void OnDestroy()
    {
        // отписка от события - смерть врага
        EventAggregator.Unsubscribe<GameIsStarted>(OnGameIsStartedEventHandler);
    }

    private void OnGameIsStartedEventHandler(object sender, GameIsStarted eventData)
    {
        // появляется и пролетает над головами вражеский транспортник
        Instantiate(_enemyJetPlane);
        AudioManager.PlaySFX(SFXType.EnemyJetLanding);
    }


    // отловить событие начала игры и тыкнуть картуину
    // StartCoroutine(TestCoroutine());

    /*
     
     IEnumerator TestCoroutine()
        {
	        while(true)
	        {
		        yield return null;
		        Debug.Log(Time.deltaTime);
	        }
        }
     */

}
