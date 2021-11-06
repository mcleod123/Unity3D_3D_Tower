using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{

    [SerializeField] private GameObject _lifesCounter;
    [SerializeField] private GameObject _lifeChangeEffect;

    private int _gamerLives = SettingsController.CountGamersLifes;
    private Text _lifesCounterText;

    // Start is called before the first frame update
    void Start()
    {
        _lifesCounterText = _lifesCounter.GetComponent<Text>();
        SetGamersLifesTextValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // подписка на событие - враг дошел до Финиша
        EventAggregator.Subscribe<EnemyWasMovedToFinish>(OnEnemyEnemyWasMovedToFinishHandler);
    }

    private void OnDestroy()
    {
        // отписка оь события - враг дошел до Финиша
        EventAggregator.Subscribe<EnemyWasMovedToFinish>(OnEnemyEnemyWasMovedToFinishHandler);
    }

    // Враг дошел до финиша и минус одна жизнь
    private void OnEnemyEnemyWasMovedToFinishHandler(object sender, EnemyWasMovedToFinish eventData)
    {
        _gamerLives -= 1;
        SetGamersLifesTextValue();

        if (_gamerLives == 0)
        {
            Debug.Log("ЖИЗНИ БОЛЬШЕ НЕТ");

            // LifeIsEmpty
            GameController.Instance.StopGame();


            // событие старта игры
            var eventLifeIsEmptyData = new LifeIsEmpty() { };
            EventAggregator.Post(this, eventLifeIsEmptyData);
        }

    }

    private void SetCoinsChangeEffect()
    {
        var lifefChangeEffect = Instantiate(_lifeChangeEffect);
        Destroy(lifefChangeEffect, 0.5f);
    }



    private void SetGamersLifesTextValue()
    {
        _lifesCounterText.text = _gamerLives.ToString();
        SetCoinsChangeEffect();
    }


}
