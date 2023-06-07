using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReducer : MonoBehaviour
{
    public int adjustSecRemoved = 5;
    TimeCounter timeCounterRef;
    public AudioClip boosterSound;


    void Awake()
    {
        Core.PlayerDetails.timeReducers.Add(this);
    }
    void Start()
    {
        timeCounterRef = Object.FindObjectOfType<TimeCounter>();
    }
    public void returnRemovedSec()
    {
        timeCounterRef.timeCounter -= adjustSecRemoved;

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
