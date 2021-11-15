using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    [SerializeField] private GameObject _gameOverWindow;

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


        // событие стоп игры
        var eventData = new GameIsStoped() { };
        EventAggregator.Post(this, eventData);




        GameIsStarting = false;
        _gameOverWindow.SetActive(true);



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
