using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedBooster : MonoBehaviour
{
    public Sprite rabbitTextureUI;
    public Image UIrabbitImage;
    public int boostSpeed = 3;
    public int durationSec = 5;
    public AudioClip boosterSound;

    void Awake()
    {
        Core.PlayerDetails.speedBoosters.Add(this);
    }

    public void speedBoost()
    {
        Core.PlayerDetails.speed *= boostSpeed;

        bool boosterActive = false;
        UIrabbitImage.sprite = rabbitTextureUI;
        UIrabbitImage.gameObject.SetActive(true);



        for (int i = 0; i < Core.PlayerDetails.boosters.Count; i++)
        {
           
            if (Core.PlayerDetails.boosters[i].typeOfBooster == BoosterType.SpeedReduser)
            {
                Core.PlayerDetails.boosters.RemoveAt(i);
            }

           
            if (Core.PlayerDetails.boosters[i].typeOfBooster == BoosterType.SpeedBoster)
            {
                Core.PlayerDetails.boosters[i].duration = durationSec;
                boosterActive = true;
                return;
            }

        }

        if (boosterActive == false)
        {
            Booster temp = new Booster();
            temp.typeOfBooster = BoosterType.SpeedBoster;
            temp.duration = durationSec;
            Core.PlayerDetails.boosters.Add(temp);
        }

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
