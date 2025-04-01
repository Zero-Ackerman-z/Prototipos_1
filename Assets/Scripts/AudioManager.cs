using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonPersistent<AudioManager>
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip foodSFX;
    private bool isOn = true;
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
            sfxSource.PlayOneShot(clip);
    }
    public void PlayFoodSFX()
    {
        if (sfxSource != null && foodSFX != null)
            sfxSource.PlayOneShot(foodSFX);
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (backgroundMusic != null && clip != null)
        {
            if (backgroundMusic.clip != clip)
            {
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
            }
        }
    }

    public void ToggleMusic()
    {
        if (backgroundMusic != null)
        {
            isOn = !isOn;  
            backgroundMusic.mute = !isOn;  
        }
    }
}
