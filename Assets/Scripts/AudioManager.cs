using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainSource;
    public AudioSource noiseSource;

    public AudioClip cooking;
    public AudioClip mainMusic;
    public AudioClip door;
    public AudioClip pc;
    public AudioClip phone;
    public AudioClip phoneRing;

    float targetVolume = 0.05f;

    private void Update()
    {
        if (mainSource.volume >= targetVolume)
            mainSource.volume -= 0.0001f;
        if (mainSource.volume < targetVolume)
            mainSource.volume += 0.0001f;
    }

    public void playMainMusic()
    {
        mainSource.clip = mainMusic;
        mainSource.Play();
    }

    public void playPC()
    {
        noiseSource.Stop();
        noiseSource.clip = pc;
        noiseSource.Play();
    }

    public void playCook()
    {
        noiseSource.Stop();
        noiseSource.clip = cooking;
        noiseSource.Play();
    }

    public void playPhone()
    {
        noiseSource.Stop();
        noiseSource.clip = phone;
        noiseSource.Play();
    }

    public void playDoor()
    {
        noiseSource.Stop();
        noiseSource.clip = door;
        noiseSource.Play();
    }

    public void fadeOutMainMusic()
    {
         targetVolume = 0f;
    }

    public void fadeInMusic()
    {
         targetVolume = 0.05f;
    }

    public void fadeToMain()
    {
        mainSource.Stop();
        mainSource.loop = false;
        mainSource.clip = mainMusic;
        mainSource.Play();
    }
}
