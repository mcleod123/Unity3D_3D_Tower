using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseButtonController : MonoBehaviour
{

    [SerializeField] private Button _pauseButton;



    void Start()
    {
        _pauseButton.onClick.AddListener(PauseButtonOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {

        // если играть с десктопа для удобства - кнопочки
        // Пауза игры
        if (Input.GetKey(KeyCode.P))
        {
            PauseGame();
        }

        // Пауза игры
        if (Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
        // ====================
    }


    private void PauseButtonOnClick()
    {

        // TextMeshProUGUI pauseButtonText = _pauseButton.GetComponentInChildren<TextMeshProUGUI>();

        // если уже на пайзе
        if (Time.timeScale == 0)
        {
            // то снимем с паузы
            ResumeGame();
        } 
        else 
        {
            // если игра не на паузе, то поставим на паузу
            PauseGame();
        }
    }


    private void PauseGame()
    {
        AudioManager.MuteMusic(true);
        _pauseButton.GetComponentInChildren<Text>().text = SettingsController.PauseButtonTextOnPause;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        AudioManager.MuteMusic(false);
        _pauseButton.GetComponentInChildren<Text>().text = SettingsController.PauseButtonTextOnPlay;
        Time.timeScale = 1;
    }







}
