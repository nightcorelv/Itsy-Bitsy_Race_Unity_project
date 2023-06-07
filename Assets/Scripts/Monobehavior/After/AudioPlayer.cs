using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip mainMenu;
    public AudioClip inGame;

    [HideInInspector]
    public bool isPlayingMainMenu = false;
    AudioSource audioSource;
    bool followPlayer;
    Camera cam = null;

    private void Awake()
    {
        if (Core.PlayerDetails.audioPlayer != null)
        {
            Destroy(this.gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        Core.PlayerDetails.audioPlayer = this;
        Object.DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (followPlayer && Core.PlayerDetails.playerCarBody != null)
        {
            this.transform.position = Core.PlayerDetails.playerCarBody.transform.position;
        }
        else
        {
            if (cam == null)
            {
                cam = Object.FindObjectOfType<Camera>();
            }
            this.transform.position = cam.transform.position;
        }
    }
    public void playMainMenu()
    {
        if (mainMenu != null)
        {
            audioSource.Stop();
            audioSource.clip = mainMenu;
            audioSource.Play();
            followPlayer = false;
            isPlayingMainMenu = true;
        }
    }
    public void playInGame()
    {
        if (inGame != null)
        {
            audioSource.Stop();
            audioSource.clip = inGame;
            audioSource.Play();
            followPlayer = true;
            isPlayingMainMenu = false;
        }
    }
    public void pauseAudio()
    {
        audioSource.Pause();
    }
    public void continueAudio()
    {
        audioSource.UnPause();
    }
}
