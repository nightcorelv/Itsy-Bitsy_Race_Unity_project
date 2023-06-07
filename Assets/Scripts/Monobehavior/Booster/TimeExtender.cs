using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExtender : MonoBehaviour
{
    public int adjustSecAdded =10;
    TimeCounter timeCounterRef;
    public AudioClip boosterSound;


    void Awake()
    {
        Core.PlayerDetails.timeExtenders.Add(this);
        

    }
    void Start()
    {
        timeCounterRef = Object.FindObjectOfType<TimeCounter>();
    }

    public void returnExtraSec()
    {
        timeCounterRef.timeCounter += adjustSecAdded;

        if (boosterSound != null)
        {
            AudioSource.PlayClipAtPoint(boosterSound, transform.position);
        }

        destroyIcon();
    }

    public void destroyIcon()
    {
        this.gameObject.SetActive(false);
    }

  
}
