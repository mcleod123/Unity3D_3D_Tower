using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject _towerPlacesGroup;

    private static GameController _intance;
    public static GameController Instance;

    private bool GameIsStarting = false; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (_intance != null)
        {
            Destroy(_intance.gameObject);
        }

        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        _intance = this;
        Instance = this;
    }

    public bool AreGameIsStarting()
    {
        return GameIsStarting;
    }

    public void StartGame()
    {
        GameIsStarting = true;

        // событие старта игры
        var eventData = new GameIsStarted() {  };
        EventAggregator.Post(this, eventData);

        // нарастание нашествия врагов уровня1 их скорость и уменьшение интервала появления
        StartCoroutine(EnemyMovingFaster());
    }


    public void StopGame()
    {
        Debug.Log("Остановите игру!");

        GameIsStarting = false;

        // событие стоп игры
        var eventData = new GameIsStoped() { };
        EventAggregator.Post(this, eventData);

        // сброс параметров
        SettingsController.EnemyMovingSpeed = SettingsController.EnemyMovingSpeedStartValue;
        SettingsController.SpawnEnemyItemsInterval = SettingsController.SpawnEnemyItemsIntervalStartValue;

        SettingsController.StartCoinsVale = SettingsController.StartCoinsValeStartValue;
        SettingsController.CountGamersLifes = SettingsController.CountGamersLifesStartValue;


        // вернем на место места под башни
        ReActivateTowerPlaces();

    }


    private void ReActivateTowerPlaces()
    {
        Debug.Log("Это не шутка, надо вернуть как было");

        // _towerPlacesGroup
        foreach (Transform child in _towerPlacesGroup.GetComponentsInChildren<Transform>())
        {
            //child.gameObject.SetActive(true);
            // child.GetComponent<GameObject>().SetActive(true);

            child.gameObject.SetActive(!child.gameObject.activeSelf);

            Debug.Log(child.gameObject.name);
        }
    }


    private IEnumerator EnemyMovingFaster()
    {
        while (SettingsController.EnemyMovingSpeed <= 5f)
        {
            SettingsController.EnemyMovingSpeed += 0.1f;
            SettingsController.SpawnEnemyItemsInterval -= 0.1f;
            yield return new WaitForSeconds(15f);
        }
    }





}
