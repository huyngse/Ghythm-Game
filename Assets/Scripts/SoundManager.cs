using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("References")]
    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource sfxSource;
    private Dictionary<string, AudioClip> audioClips = new();
    public float fadeDuration = 0.5f;

    void Start()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio/sfx");
        foreach (AudioClip clip in clips)
        {
            audioClips.Add(clip.name, clip);
        }
        musicSource.clip = Resources.Load<AudioClip>("Audio/songs/song");
        musicSource.Play();
        musicSource.Stop();
    }

    public void PlayEffect(string name)
    {
        sfxSource.PlayOneShot(audioClips[name]);
    }
    public void PlaySong()
    {
        StartCoroutine(FadeIn(musicSource, fadeDuration));
    }
    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0f; 
        audioSource.Play(); 

        float startVolume = audioSource.volume;

        while (audioSource.volume < 1f) 
        {
            audioSource.volume += 1 / fadeDuration * Time.deltaTime;
            yield return null; 
        }

        audioSource.volume = 1f;
    }
}
