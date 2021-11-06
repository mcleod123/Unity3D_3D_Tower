using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{

    [SerializeField] private Button _startGameButton;
    [SerializeField] private GameObject _gameOverWindow;


    // Start is called before the first frame update
    void Start()
    {
        _gameOverWindow.SetActive(false);
        _startGameButton.onClick.AddListener(StartGameButtonOnClick);
    }

    private void StartGameButtonOnClick()
    {
        _gameOverWindow.SetActive(false);
        GameController.Instance.StartGame();
    }


    private void Update()
    {
        if (GameController.Instance.AreGameIsStarting() == false)
        {
            Debug.Log("!!!");
            _gameOverWindow.SetActive(true);

        } 
        else
        {

            _gameOverWindow.SetActive(false);

        }
    }


    private void Awake()
    {
        // подписка на событие - стоп игры
        EventAggregator.Subscribe<LifeIsEmpty>(OnLifeIsEmptyEventHandler);
    }

    private void OnDestroy()
    {
        // отписка от события - смерть врага
        EventAggregator.Unsubscribe<LifeIsEmpty>(OnLifeIsEmptyEventHandler);
    }

    private void OnLifeIsEmptyEventHandler(object sender, LifeIsEmpty eventData)
    {

    }


}
