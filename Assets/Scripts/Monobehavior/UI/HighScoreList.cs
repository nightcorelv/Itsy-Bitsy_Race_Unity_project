using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreList : MonoBehaviour
{

    public TMPro.TMP_Text highscore1;
    public TMPro.TMP_Text highscore2;
    public TMPro.TMP_Text highscore3;
    public TMPro.TMP_Text highscore4;
    public TMPro.TMP_Text highscore5;


    void Start()
    {

        if (Core.PlayerDetails.hightScoreList.Count >= 1)
        {
            highscore1.text = Core.PlayerDetails.hightScoreList[0].ToString();
        }
        if (Core.PlayerDetails.hightScoreList.Count >= 2)
        {
            highscore2.text = Core.PlayerDetails.hightScoreList[1].ToString();
        }
        if (Core.PlayerDetails.hightScoreList.Count >= 3)
        {
            highscore3.text = Core.PlayerDetails.hightScoreList[2].ToString();
        }
        if (Core.PlayerDetails.hightScoreList.Count >= 4)
        {
            highscore4.text = Core.PlayerDetails.hightScoreList[3].ToString();
        }
        if (Core.PlayerDetails.hightScoreList.Count >= 5)
        {
            highscore5.text = Core.PlayerDetails.hightScoreList[4].ToString();
        }



    }

}
