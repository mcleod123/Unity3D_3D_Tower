﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{

    [SerializeField] private Button _startGameButton;
    [SerializeField] private GameObject _towerPlacesGroup;


    // Start is called before the first frame update
    void Start()
    {
        _startGameButton.onClick.AddListener(StartGameButtonOnClick);
    }

    private void StartGameButtonOnClick()
    {
        // вернем на место места под башни
        ReActivateTowerPlaces();
        GameController.Instance.StartGame();

        AudioManager.PlaySFX(SFXType.StartGame);


        // сброс параметров
        SettingsController.EnemyMovingSpeed = SettingsController.EnemyMovingSpeedStartValue;
        SettingsController.SpawnEnemyItemsInterval = SettingsController.SpawnEnemyItemsIntervalStartValue;

        // событие старт игры
        var eventData = new GameIsStarted() { };
        EventAggregator.Post(this, eventData);

        // --
        gameObject.SetActive(false);

    }


    private void Update()
    {

    }


    private void Awake()
    {
        // подписка на событие - стоп игры
        EventAggregator.Subscribe<LifeIsEmpty>(OnLifeIsEmptyEventHandler);

        // Game Over Sound
        AudioManager.PlaySFX(SFXType.GameOver);
    }

    private void OnDestroy()
    {
        // отписка от события - смерть врага
        EventAggregator.Unsubscribe<LifeIsEmpty>(OnLifeIsEmptyEventHandler);
    }

    private void OnLifeIsEmptyEventHandler(object sender, LifeIsEmpty eventData)
    {

    }

    private void ReActivateTowerPlaces()
    {
        #pragma warning disable CS0618 // Тип или член устарел
        // ничего страшного, зато работает как надо
        _towerPlacesGroup.SetActiveRecursively(enabled);
        #pragma warning restore CS0618 // Тип или член устарел
    }

}
