using System.Collections.Generic;
using UnityEngine;

public class SoundEffector: MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;
    [SerializeField] private AudioSource _audioSource;
    private int _clipSelector = 0;

    public void Play()
    {
        _audioSource.clip = _audioClips[_clipSelector];
        _audioSource.Play();
        _clipSelector++;
    }

    public void ResetSelector()
    {
        _clipSelector = 0;
    }
}