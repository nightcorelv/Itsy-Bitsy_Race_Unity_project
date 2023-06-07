using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishHandler : MonoBehaviour
{
    public TMP_Text lap1;
    public TMP_Text lap2;
    public TMP_Text lap3;

    public TMP_Text yourTime;
    

    void Start()
    {
        lap1.text = Core.PlayerDetails.lapOne.ToString();
        lap2.text = Core.PlayerDetails.lapTwo.ToString();
        lap3.text = Core.PlayerDetails.lapTree.ToString();

        yourTime.text = Core.PlayerDetails.gameTimeFinnish.ToString();

        Core.Hightscore.AddToHightScore(Core.PlayerDetails.gameTimeFinnish);
        GetComponent<HighScoreList>().enabled = true;
    }
}
