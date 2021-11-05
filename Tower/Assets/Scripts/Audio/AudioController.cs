using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioManager _audioManager;

    void Start()
    {
        _audioManager = AudioManager.Instance;

    }




    private void Awake()
    {

        //AudioManager.PlayMusic(MusicType.BackgroundMusic);

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
        // AudioManager.PlaySFX(SFXType.Shoot);

    }

    // постройка башни
    private void OnTowerBuildEventHandler(object sender, TowerBuildingEventData eventData)
    {
        // 555
    }


    // Враг дошел до финиша
    private void OnEnemyEnemyWasMovedToFinishHandler(object sender, EnemyWasMovedToFinish eventData)
    {
        // ***
    }



}
