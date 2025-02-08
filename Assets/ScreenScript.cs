using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenScript : MonoBehaviour
{
    public List<AudioClip> audioMovieClips = new();
   
    private AudioSource _audioSource;
    private AudioClip _lastClip;

    public void PlayAudioMovie(List<AudioClip> clips)
    {
        int clipIndex = Random.Range(0, clips.Count);
        _audioSource.clip = clips[clipIndex];
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    public void StopAudioMovie()
    {
        _audioSource.Stop();
    }
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayAudioMovie(audioMovieClips);
    }
}
