using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public float timeSinceKillBoxEnter = 0;
    bool enteredkillBox =false;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        if(enteredkillBox==true)
        {
            Core.Time.CountUpTime(ref timeSinceKillBoxEnter);
        }
        
    }

    public void SendToCheckpoint()
    {
        enteredkillBox = true;

        if (timeSinceKillBoxEnter >= 3)
        {
            Core.CheckPoint.SpawnAtLastCheckpoint();
            ResetKillBoxValues();
            
        }
        
    }

    public void playAudio()
    {
        if(audioClip != null)
        {
            if(Core.PlayerDetails.audioPlayer!=null)
            {
                Core.PlayerDetails.audioPlayer.pauseAudio();
            }
            AudioSource.PlayClipAtPoint(audioClip, this.transform.position);
        }
    }
    public void ResetKillBoxValues()
    {
        enteredkillBox = false;
        timeSinceKillBoxEnter = 0;

        if (Core.PlayerDetails.audioPlayer != null)
        {
            Core.PlayerDetails.audioPlayer.continueAudio();
        }
    }

}
