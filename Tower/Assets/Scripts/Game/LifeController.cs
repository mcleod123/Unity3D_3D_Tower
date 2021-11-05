using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{

    [SerializeField] private GameObject _lifesCounter;

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
    }

    private void SetGamersLifesTextValue()
    {
        _lifesCounterText.text = _gamerLives.ToString();
    }


}
