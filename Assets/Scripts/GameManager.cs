using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip song;
    [SerializeField]
    private BeatScroller beatScroller;
    [Header("Attributes")]
    [SerializeField]
    private bool startPlaying = false;
    void Start()
    {
        audioSource.clip = song;
        audioSource.Play();
        audioSource.Stop();
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.HasStarted = true;
                StartCoroutine(PlayAudioAfterDelay());
            }
        }
    }
    private IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.Instance.PlaySong();
    }

    public void NoteHit(int score)
    {
        Debug.Log(score);
    }

    public void NoteMiss()
    {
        Debug.Log("Miss");
    }
}
