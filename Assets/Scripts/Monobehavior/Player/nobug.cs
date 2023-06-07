using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nobug : MonoBehaviour
{
    void Start()
    {
        Core.Time.Continue();

        Core.PlayerDetails.speedBoosters = new List<SpeedBooster>();
        Core.PlayerDetails.speedReducers = new List<SpeedReducer>();
        Core.PlayerDetails.timeExtenders = new List<TimeExtender>();
        Core.PlayerDetails.timeReducers = new List<TimeReducer>();

        Core.PlayerDetails.highScore1 = default;
        Core.PlayerDetails.highScore2 = default;
        Core.PlayerDetails.highScore3 = default;
        Core.PlayerDetails.highScore4 = default;
        Core.PlayerDetails.highScore5 = default;

        Core.PlayerDetails.lap = default;
        Core.PlayerDetails.lapOne = default;
        Core.PlayerDetails.lapTwo = default;
        Core.PlayerDetails.lapTree = default;
        Core.PlayerDetails.gameTimeFinnish = default;

        Core.PlayerDetails.currentlapNumber = default;

        Core.PlayerDetails.speed = 1;
        Core.PlayerDetails.maxSpeed = 1;

        Core.PlayerDetails.boosters = new List<Booster>();
        Core.PlayerDetails.steerType = default;
        Core.PlayerDetails.playerSelectedCar = CarType.Jocob;

        Core.PlayerDetails.currentTime = default;
        Core.PlayerDetails.SpeedBoosterOn = true;

        Core.CheckPoint.checkPointTransform = new List<CheckPointPosition>();
        Core.CheckPoint.checkpointsList = new List<CheckPointBox>();
        Core.CheckPoint.currentCheckpointIndex = 0;
        Core.CheckPoint.currentCheckpointNr = 0;

        Core.Hightscore.rank = -1;


        if (Core.PlayerDetails.audioPlayer != null)
        {
            if(Core.PlayerDetails.audioPlayer.isPlayingMainMenu == false)
            {
                Core.PlayerDetails.audioPlayer.continueAudio();
                Core.PlayerDetails.audioPlayer.playMainMenu();
            }

        }
    }

}
