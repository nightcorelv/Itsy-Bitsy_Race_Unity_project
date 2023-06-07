using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnCheck : MonoBehaviour
{
    public TMPro.TMP_Text text;
    Rigidbody carRigidbody = null;
    public float time = 3;
    float currentTime = 0;

    void Update()
    {
        if (carRigidbody == null)
        {
            carRigidbody = Core.PlayerDetails.playerCarBody.GetComponent<Rigidbody>();
        }
        else
        {
            if (carRigidbody.velocity.magnitude < 1)
            {
                Core.Time.CountUpTime(ref currentTime);

                if(currentTime >= time)
                {
                    text.gameObject.SetActive(true);
                }

            }
            else
            {
                currentTime = 0;
                text.gameObject.SetActive(false);
            }
        }

    }
}
