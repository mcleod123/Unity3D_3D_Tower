using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPreferences : MonoBehaviour
{

    private const float _soundVolume = 10f;
    private const string _settingSoundVolumeName = "SoundVolume";


    public static float GetSoundVolume()
    {
        return GetSavedSoundVolume();
    }

    public static void SetDefaultSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat(_settingSoundVolumeName, volume);
    }


    // если игра ранее запускалась, то попробуем установить уровень звука, как был выставлен в прощлый запуск
    private static float GetSavedSoundVolume()
    {
        float currentVolume;

        #pragma warning disable CS0472 // Результат значения всегда одинаковый, так как значение этого типа никогда не равно NULL
        // тут мы проверяем, что эта настройка вообще существует, если не существует, то записываем значения
        if ( (PlayerPrefs.GetFloat(_settingSoundVolumeName))== null)
        #pragma warning restore CS0472 // Результат значения всегда одинаковый, так как значение этого типа никогда не равно NULL
        {
            PlayerPrefs.SetFloat(_settingSoundVolumeName, _soundVolume);
            currentVolume = _soundVolume;
        } 
        else
        {
            currentVolume = PlayerPrefs.GetFloat(_settingSoundVolumeName);
        }

        return currentVolume;
    }



}
