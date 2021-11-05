using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{

    [SerializeField] private GameObject _statList;
    private Text _statListText;

    // Start is called before the first frame update
    void Start()
    {
        _statListText = _statList.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // подписка на событие - смерть врага
        EventAggregator.Subscribe<EnemyDeathEventData>(OnEnemyDeathEventHandler);

        // подписка на событие - постройка башни
        EventAggregator.Subscribe<TowerBuildingEventData>(OnTowerBuildEventHandler);

        // подписка на событие - враг дошел до Финиша
        EventAggregator.Subscribe<EnemyWasMovedToFinish>(OnEnemyEnemyWasMovedToFinishHandler);
    }

    private void OnDestroy()
    {
        // отписка от события - смерть врага
        EventAggregator.Unsubscribe<EnemyDeathEventData>(OnEnemyDeathEventHandler);

        // jотписка от событие - постройка башни
        EventAggregator.Unsubscribe<TowerBuildingEventData>(OnTowerBuildEventHandler);

        // отписка оь события - враг дошел до Финиша
        EventAggregator.Subscribe<EnemyWasMovedToFinish>(OnEnemyEnemyWasMovedToFinishHandler);
    }

    // смерть врага
    private void OnEnemyDeathEventHandler(object sender, EnemyDeathEventData eventData)
    {
        SetStatTextValue("Уничтожена вражеская единица: " + eventData.Enemy);

    }

    // постройка башни
    private void OnTowerBuildEventHandler(object sender, TowerBuildingEventData eventData)
    {
        SetStatTextValue("Построена башня: " + eventData.TowerTypeData);
    }


    // Враг дошел до финиша
    private void OnEnemyEnemyWasMovedToFinishHandler(object sender, EnemyWasMovedToFinish eventData)
    {
        SetStatTextValue("Враг дошел до финиша: " + eventData.Enemy);
    }


    private void SetStatTextValue(string addValue)
    {
        var oldText = _statListText.text;
        _statListText.text = oldText + "\n" + addValue;
    }



}
