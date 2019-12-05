using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioClip[] shootingSounds;
    [SerializeField] private AudioClip[] hitHoleSounds;
    [SerializeField] private AudioClip failSound;
    [SerializeField] private AudioClip highScoreSound;
    private AudioSource audioSource;
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootingSounds[Random.Range(0, shootingSounds.Length)]);
    }

    public void PlayFailSound()
    {
        audioSource.PlayOneShot(failSound);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitHoleSounds[Random.Range(0, hitHoleSounds.Length)]);
    }

    public void PlayHighScoreSound()
    {
        audioSource.PlayOneShot(highScoreSound);
    }

}
