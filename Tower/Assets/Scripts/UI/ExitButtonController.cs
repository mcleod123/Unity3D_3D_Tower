using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonController : MonoBehaviour
{

    [SerializeField] private Button _exitButton;


    void Start()
    {
        _exitButton.onClick.AddListener(ExitButtonOnClickHandler);
    }


    void Update()
    {
        // Выход из игры по нажатию кнопки Escape или ее аналога на андроиде
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void ExitButtonOnClickHandler()
    {
        QuitGame();
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }



}
