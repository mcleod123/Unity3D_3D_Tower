using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFXType
{
    Shoot,
    TowerBuildComplete,
    EnemyCatDied,
    EnemyJetLanding,
    MetalBulletHit
}

public enum MusicType
{
    BackgroundMusic
}


public class AudioManager : MonoBehaviour
{
    private static AudioManager _intance;
    public static AudioManager Instance;

    [SerializeField] private List<SFXData> _sfxDataList = new List<SFXData>();
    [SerializeField] private List<MusicData> _musicDataList = new List<MusicData>();

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

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

    private void PlayMusicInner(MusicType type)
    {
        var musicData = GetMusicData(type);
        if (musicData != null)
        {
            _musicSource.clip = musicData.Clip;
            _musicSource.Play();
        }
    }

    public void PlayMusic2(MusicType musicType)
    {
        PlayMusicInner(musicType);
    }

    private MusicData GetMusicData(MusicType type)
    {
        var result = _musicDataList.Find(data => data.Type == type);
        return result;
    }

    private void PlaySFXInner(SFXType type)
    {
        var sfxData = GetSFXData(type);
        if (sfxData != null)
        {
            _sfxSource.PlayOneShot(sfxData.Clip);
        }
    }

    private SFXData GetSFXData(SFXType type)
    {
        var result = _sfxDataList.Find(data => data.Type == type);
        return result;
    }

    private void MuteMusicInner(bool mute)
    {
        _musicSource.mute = mute;
    }

    private void MuteSfxInner(bool mute)
    {
        _musicSource.mute = mute;
    }

    public static void PlayMusic(MusicType musicType)
    {
        _intance.PlayMusicInner(musicType);
    }

    public static void PlaySFX(SFXType type)
    {
        _intance.PlaySFXInner(type);
    }

    public static void MuteSfx(bool mute)
    {
        _intance.MuteSfxInner(mute);
    }

    public static void MuteMusic(bool mute)
    {
        _intance.MuteMusicInner(mute);
    }

}

[System.Serializable]
public class SFXData
{
    public AudioClip Clip;
    public SFXType Type;
}

[System.Serializable]
public class MusicData
{
    public AudioClip Clip;
    public MusicType Type;
}
