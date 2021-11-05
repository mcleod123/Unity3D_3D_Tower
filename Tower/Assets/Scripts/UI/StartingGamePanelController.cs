using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartingGamePanelController : MonoBehaviour
{

    [SerializeField] private Button _startGameButton;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private AudioMixer _mixer;


    // Start is called before the first frame update
    void Start()
    {
        _startGameButton.onClick.AddListener(StartGameButtonOnClick);
        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void StartGameButtonOnClick()
    {
        gameObject.SetActive(false);
        GameController.Instance.StartGame();
    }


    private void OnMasterVolumeChanged(float value)
    {
        // AudioManager.Instance.
        // mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        //_mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);

        // _mixer.FindMatchingGroups("Master").SetValue(AudioMixer.Equals(  value, 0);

        _mixer.SetFloat("MusicMasterVolume", value);

    }






}
