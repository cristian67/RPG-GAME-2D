using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;
    private AudioSource _audioSource;

    //Singleton
    public static MusicManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic(0);
    }

    public void PlayMusic(int indice)
    {
        _audioSource.clip = music[indice];
        _audioSource.Play();        
    }
   
}
