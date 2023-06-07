using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TMP_Text highScore1Text;
    public TMP_Text highScore2Text;
    public TMP_Text highScore3Text;
    public TMP_Text highScore4Text;
    public TMP_Text highScore5Text;

    public TMP_Text lap1Text;
    public TMP_Text lap2Text;
    public TMP_Text lap3Text;

    public TMP_Text playerScooreText;

    // Start is called before the first frame update
    void Start()
    {  
        playerScooreText.color= Color.yellow;
        playerScooreText.text = Core.PlayerDetails.gameTimeFinnish.ToString();

        lap1Text.text = Core.PlayerDetails.lapOne.ToString();
        lap2Text.text = Core.PlayerDetails.lapTwo.ToString();
        lap3Text.text = Core.PlayerDetails.lapTree.ToString();

        for(int i =0;i< Core.PlayerDetails.hightScoreList.Count;i++)///ändra färg om playertime i highscorelistan
        {
            if (Core.PlayerDetails.hightScoreList[i] == Core.PlayerDetails.gameTimeFinnish)
            {
                
            }
        }
        

        highScore1Text.text = Core.PlayerDetails.highScore1.ToString();
        highScore2Text.text = Core.PlayerDetails.highScore2.ToString();
        highScore3Text.text = Core.PlayerDetails.highScore3.ToString();
        highScore4Text.text = Core.PlayerDetails.highScore4.ToString();
        highScore5Text.text = Core.PlayerDetails.highScore5.ToString();
    }




    // Update is called once per frame
    void Update()
    {
        
    }




}
