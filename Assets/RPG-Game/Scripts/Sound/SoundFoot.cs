using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFoot : MonoBehaviour
{

    private AudioSource _audioSource;

    [SerializeField]
    [Range(-3,3)]
    private float pitchMin;

    [SerializeField]
    [Range(-3, 3)]
    private float pitchMaximo;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.pitch = Random.Range(pitchMin, pitchMaximo);
        _audioSource.Play();
    }
}
