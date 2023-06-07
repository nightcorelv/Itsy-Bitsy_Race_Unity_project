using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinishLineTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    int onLapNr = 0;
    public TMP_Text lapNrText;
    public GameObject MrBuffKnuckles;

    public  TMP_Text timeLapOneTextOnScreen;
    public  TMP_Text timeLapTwoTextOnScreen;
    public  TMP_Text timeLapThreeTextOnScreen;

    void Start()
    {
        lapNrText.text = onLapNr.ToString();
        Core.PlayerDetails.timeLapOneTextOnScreen = timeLapOneTextOnScreen;
        Core.PlayerDetails.timeLapTwoTextOnScreen = timeLapTwoTextOnScreen;
        Core.PlayerDetails.timeLapThreeTextOnScreen = timeLapThreeTextOnScreen;
        Core.PlayerDetails.currentlapNumber = onLapNr;
        MrBuffKnuckles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lapNrText.text = ("Lap: ")+onLapNr.ToString();

    }

    public void callOnNewLap(GameObject timeCount)
    {
        if(Core.CheckPoint.currentCheckpointIndex == 4)
        {
            timeCount.GetComponent<TimeCounter>().timeCounter += 100;
            onLapNr += 1;

            //spara tid för varv  Lap 1 lap 2 lap 3
            if (onLapNr == 1)
            {
                Core.PlayerDetails.lapOne = timeCount.GetComponent<TimeCounter>().TimeSinceRaceStart;
                Core.PlayerDetails.timeLapOneTextOnScreen.text = "Lap1: "+ Core.PlayerDetails.lapOne.ToString()+" Sec";
            }
            if (onLapNr == 2)
            {
                Debug.Log("onLapNr: " + onLapNr);
                Core.PlayerDetails.lapTwo = timeCount.GetComponent<TimeCounter>().TimeSinceRaceStart;
                Core.PlayerDetails.lapTwo -= Core.PlayerDetails.lapOne;
                Core.PlayerDetails.timeLapTwoTextOnScreen.text = "Lap2: "+ Core.PlayerDetails.lapTwo.ToString()+ " Sec";
                Debug.Log("timeLapTwoTextOnScreen: " + timeLapTwoTextOnScreen);
            }
            if (onLapNr == 3)
            {
                Debug.Log("onLapNr: " + onLapNr);
                Core.PlayerDetails.lapTree= timeCount.GetComponent<TimeCounter>().TimeSinceRaceStart;
                Core.PlayerDetails.lapTree-= (Core.PlayerDetails.lapOne + Core.PlayerDetails.lapTwo);
                Core.PlayerDetails.timeLapThreeTextOnScreen.text = "Lap3: " + Core.PlayerDetails.lapTree.ToString()+ " Sec";
                Core.PlayerDetails.gameTimeFinnish = timeCount.GetComponent<TimeCounter>().TimeSinceRaceStart;
                
                //go to finnish scene
                Core.Scene.OpenScene("Finnish");
              
                Debug.Log("timeLapThreeTextOnScreen: " + timeLapThreeTextOnScreen);
            }    
            
            //sätt currentlapnr p?core
            Core.PlayerDetails.currentlapNumber = onLapNr;
            Debug.Log(Core.PlayerDetails.currentlapNumber);
            //respawn boosters
            Core.Time.spawnBoosters();
            //reactivate checkpoints
            Core.CheckPoint.ResetAllCheckpoints();

            int randNr = Random.Range(0, 4);
            if(randNr==1)
            {
                MrBuffKnuckles.SetActive(true);
            }
            else
            {
                MrBuffKnuckles.SetActive(false);
            }
        }
    }
}
