using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance = null;

    [SerializeField]
    private AudioSource _bgmPrefab = null;

    [SerializeField]
    private AudioClip[] _bgmClips = new AudioClip[0];

    private AudioSource _bgm = null;

    [SerializeField]
    private AudioSource _sfxPrefab = null;

    private AudioSource _sfx = null;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Objek \"Audio Manager\" sudah ada.\n Hapus Objek Serupa", instance);
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        _bgm = Instantiate(_bgmPrefab);
        DontDestroyOnLoad(_bgm);

        _sfx = Instantiate(_sfxPrefab);
        DontDestroyOnLoad(_sfx);

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDestroy()
    {
        if (this.Equals(instance))
        {
            instance = null;

            if (_bgm != null)
                Destroy(_bgm.gameObject);
        }
    }

    public void PlayBGM(int index)
    {
        if (_bgm.clip == _bgmClips[index])
            return;

        _bgm.clip = _bgmClips[index];
        _bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {       
        _sfx.PlayOneShot(clip);
    }
}
