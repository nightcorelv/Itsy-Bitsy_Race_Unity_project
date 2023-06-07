using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
   public float TimeSinceRaceStart =0; 
   public float timeCounter = 30;
   public GameObject gameOverObject;
   bool gameOver = false;
   public TMP_Text timeText;

    private void Awake()
    {
        Core.PlayerDetails.timeCounter = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = ((int)timeCounter).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Core.Time.CountDownTime(ref timeCounter);
        Core.Time.CountUpTime(ref TimeSinceRaceStart);
        timeText.text = ((int)timeCounter).ToString();
        if(timeCounter<10)
        {
            timeText.color = Color.red;
        }
        else
        {
            timeText.color = Color.yellow;
        }


        if (timeCounter<=0 && gameOver==false)
        {
            gameOver = true;
            Object.Instantiate(gameOverObject);

        }

        Core.PlayerDetails.currentTime = TimeSinceRaceStart;
    }

    public void resetTime()
    {
        Transform position = null;
        //fix
        foreach (CheckPointPosition index in Core.CheckPoint.checkPointTransform)
        {
            if (Core.CheckPoint.currentCheckpointIndex == index.index)
            {
                position = index.transform;
                break;
            }
        }
        timeCounter = position.gameObject.GetComponent< CheckPointPosition >().checkPointEnterTime;
    }
   
}
