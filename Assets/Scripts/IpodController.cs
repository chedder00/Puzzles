using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IpodController : MonoBehaviour {

    public AudioClip[] _clips;
    private int _currentlyPlaying;
    private AudioSource _audio;
    public Text screen;
    void Start()
    {
        screen.text = "";
        _currentlyPlaying = 0;
        _audio = GetComponent<AudioSource>();
        _audio.clip = _clips[_currentlyPlaying];
    }


    public void Play()
    {
        Debug.Log(_clips[_currentlyPlaying].name);
        screen.text = _clips[_currentlyPlaying].name;
        _audio.Play();
    }

    public void Stop()
    {
        _audio.Stop();
    }

    public void Skip()
    {
        Stop();
        if (++_currentlyPlaying >= _clips.Length)
            _currentlyPlaying = 0;
        _audio.clip = _clips[_currentlyPlaying];
        Play();
    }

    public void Back()
    {
        Stop();
        if (--_currentlyPlaying < 0)
            _currentlyPlaying = _clips.Length - 1;
        _audio.clip = _clips[_currentlyPlaying];
        Play();
    }
}
