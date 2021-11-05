using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private GameObject _coinsCounter;

    private static CoinsController _intance;
    public static CoinsController Instance;

    private int _currentCoinsValue = SettingsController.StartCoinsVale;
    private Text _coinsCounterText;


    // Start is called before the first frame update
    void Start()
    {
        _coinsCounterText = _coinsCounter.GetComponent<Text>();
        SetCurrentCoinsValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AreWeCanBuildBuildings(int buildingCost)
    {
        if( buildingCost <= _currentCoinsValue )
        {
            Debug.Log("Есть деньги, башню строим!");
            return true;
        } else
        {
            Debug.Log("На постройку башни денег нет!");
            return false;
        }
    }

    private void SetCurrentCoinsValue()
    {
        _coinsCounterText.text = _currentCoinsValue.ToString();
    }



    void Awake()
    {
        // подписка на событие - смерть врага
        EventAggregator.Subscribe<EnemyDeathEventData>(OnEnemyDeathEventHandler);

        // подписка на событие - постройка башни
        EventAggregator.Subscribe<TowerBuildingEventData>(OnTowerBuildEventHandler);



        // =================================
        // для использования в других класах
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
        // ===============================
        // ===============================


    }

    private void OnDestroy()
    {
        // отписка от события - смерть врага
        EventAggregator.Unsubscribe<EnemyDeathEventData>(OnEnemyDeathEventHandler);

        // jотписка от событие - постройка башни
        EventAggregator.Unsubscribe<TowerBuildingEventData>(OnTowerBuildEventHandler);
    }


    // смерть врага - прибавим денежек
    private void OnEnemyDeathEventHandler(object sender, EnemyDeathEventData eventData)
    {
        _currentCoinsValue += eventData.EnemyDeathCost;
        SetCurrentCoinsValue();
        
    }

    // постройка башни - убавим денежек
    private void OnTowerBuildEventHandler(object sender, TowerBuildingEventData eventData)
    {
        _currentCoinsValue -= eventData.TowerBuildingCost;
        SetCurrentCoinsValue();
        // Debug.Log("Разорились на постройке башен");
    }




}
