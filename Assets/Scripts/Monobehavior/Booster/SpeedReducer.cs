using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedReducer : MonoBehaviour
{
    public Sprite snailTextureUI;
    public Image UIsnailImage;
    public int adjustLostSpeed = 4;
    public AudioClip boosterSound;

    void Awake()
    {
        Core.PlayerDetails.speedReducers.Add(this);
    }

    public void reduseSpeed()
    {
        Core.PlayerDetails.speed /= adjustLostSpeed;
        bool boosterActive = false;
        UIsnailImage.sprite = snailTextureUI;
        UIsnailImage.gameObject.SetActive(true);

        if (Core.PlayerDetails.boosters.Count > 0)
        {
            for (int i = 0; i < Core.PlayerDetails.boosters.Count; i++)
            {
                //exempel remove booster
                if (Core.PlayerDetails.boosters[i].typeOfBooster == BoosterType.SpeedBoster)
                {
                    Core.PlayerDetails.boosters.RemoveAt(i);
                }

                //exempel till check booster som redan finns
                if (Core.PlayerDetails.boosters[i].typeOfBooster == BoosterType.SpeedReduser)
                {
                    Core.PlayerDetails.boosters[i].duration = 10;
                    boosterActive = true;
                    return;
                }

            }
        }


        if (boosterActive == false)
        {
            //decal booster variable
            Booster temp = new Booster();
            //set booster type
            temp.typeOfBooster = BoosterType.SpeedReduser;
            //set booster duration
            temp.duration = 10;
            //add it to booster array
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
