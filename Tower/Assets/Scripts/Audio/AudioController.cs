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
        // подписка на событие - постройка башни
        EventAggregator.Subscribe<TowerBuildingEventData>(OnTowerBuildEventHandler);
    }

    private void OnDestroy()
    {
        // jотписка от событие - постройка башни
        EventAggregator.Unsubscribe<TowerBuildingEventData>(OnTowerBuildEventHandler);
    }



    // постройка башни
    private void OnTowerBuildEventHandler(object sender, TowerBuildingEventData eventData)
    {
        AudioManager.PlaySFX(SFXType.TowerBuild);
    }


}
