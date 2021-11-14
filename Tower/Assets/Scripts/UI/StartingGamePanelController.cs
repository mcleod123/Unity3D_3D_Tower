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

    private const string _mixerName = "MusicMasterVolume";

    // Start is called before the first frame update
    void Start()
    {
        _startGameButton.onClick.AddListener(StartGameButtonOnClick);
        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);


        // установим значение громкости
        _mixer.SetFloat(_mixerName, UserPreferences.GetSoundVolume());
        _masterVolumeSlider.value = UserPreferences.GetSoundVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void StartGameButtonOnClick()
    {
        gameObject.SetActive(false);
        GameController.Instance.StartGame();

        AudioManager.PlaySFX(SFXType.StartGame);
    }


    private void OnMasterVolumeChanged(float value)
    {
        _mixer.SetFloat(_mixerName, value);
        UserPreferences.SetDefaultSoundVolume(value);
    }






}
