using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFoot : MonoBehaviour
{

    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
