using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;

#endif


public enum DirtyLevelType
{
    NoneDirt,
    HalfDirt,
    FullDirt
}
public enum BoosterType
{
    SpeedBoster,
    SpeedReduser
}

public enum SteerType
{
    FrontWheelDrive,
    RearWheelDrive,
    FourWheelDrive
}

public enum CarType
{
    None = 0,
    Jocob = 1,
    Liye = 2,
    Zannie = 3
}

public class Booster
{
    public BoosterType typeOfBooster;
    public float duration = 10;
    public float currentDuration = 0;
}

namespace Core
{
    public static class Time
    {

        public static float CountDownTime(ref float currentTime)
        {
            currentTime -= UnityEngine.Time.deltaTime;
            return currentTime;
        }
        public static float CountUpTime(ref float currentTime)
        {
            currentTime += UnityEngine.Time.deltaTime;
            return currentTime;
        }
        public static void Pause()
        {
            UnityEngine.Time.timeScale = 0;
        }
        public static void Continue()
        {
            UnityEngine.Time.timeScale = 1;
        }
        public static void spawnBoosters()
        {
            foreach(var obj in PlayerDetails.speedBoosters)
            {
                obj.gameObject.SetActive(true);
            }
            foreach (var obj in PlayerDetails.speedReducers)
            {
                obj.gameObject.SetActive(true);
            }
            foreach (var obj in PlayerDetails.timeExtenders)
            {
                obj.gameObject.SetActive(true);
            }
            foreach (var obj in PlayerDetails.timeReducers)
            {
                obj.gameObject.SetActive(true);
            }
        }
    }

    public static class PlayerDetails
    {
        public static List<SpeedBooster> speedBoosters = new List<SpeedBooster>();
        public static List<SpeedReducer> speedReducers = new List<SpeedReducer>();
        public static List<TimeExtender> timeExtenders = new List<TimeExtender>();
        public static List<TimeReducer> timeReducers = new List<TimeReducer>();

        public static TMP_Text timeLapOneTextOnScreen;
        public static TMP_Text timeLapTwoTextOnScreen;
        public static TMP_Text timeLapThreeTextOnScreen;

        public static float highScore1;
        public static float highScore2;
        public static float highScore3;
        public static float highScore4;
        public static float highScore5;
       
        public static float lap = 0;//inte varv1
        public static float lapOne = 0;
        public static float lapTwo = 0;
        public static float lapTree = 0;
        public static float gameTimeFinnish = 0;

        public static List<float> hightScoreList = new List<float>();

        public static int currentlapNumber;

        public static float speed = 1;
        public static float maxSpeed = 1;
        public static GameObject player;
        public static GameObject playerCarBody;
        public static List<Booster> boosters = new List<Booster>();
        public static TimeCounter timeCounter;

        public static AudioPlayer audioPlayer = null;

        public static SteerType steerType;

        public static CarType playerSelectedCar = CarType.Jocob;

        public static float currentTime;
        public static bool SpeedBoosterOn = true;

        //change dirty level in game
        public static void ChangeDirtyLevel(DirtyLevelType dirtyLevel)
        {
            player.GetComponent<Player>().changeDirtyLevel(dirtyLevel);
        }
    }

    public static class CheckPoint
    {
        public static List<CheckPointPosition> checkPointTransform = new List<CheckPointPosition>();
        public static int currentCheckpointNr = 0;
        public static int currentCheckpointIndex = 0;
        public static List<CheckPointBox> checkpointsList = new List<CheckPointBox>();
        public static TMPro.TMP_Text checkpointText;

        public static void ResetAllCheckpoints()
        {

            currentCheckpointIndex = 0;

            foreach (CheckPointPosition index in checkPointTransform)
            {
                index.ResetCheckPoint();
            }
        }

        public static void SpawnAtLastCheckpoint()
        {
            GameObject position = null;

            foreach (CheckPointPosition index in checkPointTransform)
            {
                if (currentCheckpointIndex == index.index)
                {
                    position = index.gameObject;
                    break;
                }
            }
            Debug.Log(position);
            PlayerDetails.playerCarBody.GetComponent<Rigidbody>().isKinematic = true;
            PlayerDetails.playerCarBody.transform.position = new Vector3(position.transform.position.x, position.transform.position.y, position.transform.position.z);
            PlayerDetails.playerCarBody.transform.rotation = new Quaternion(position.transform.rotation.x, position.transform.rotation.y, position.transform.rotation.z, position.transform.rotation.w);
            PlayerDetails.playerCarBody.GetComponent<Rigidbody>().isKinematic = false;
            PlayerDetails.currentTime = position.gameObject.GetComponent<CheckPointPosition>().checkPointEnterTime;
            PlayerDetails.timeCounter.resetTime();


        }
    }

    //control scenes
    public static class Scene
    {
        //open scene and unload att other scenes
        public static void OpenScene(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }

        //add scene into current scene
        public static void AddScene(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }

        //remove scene by name
        public static void RemoveScene(string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }

        //remove scene by scene
        public static void RemoveScene(UnityEngine.SceneManagement.Scene scene)
        {
            SceneManager.UnloadSceneAsync(scene);
        }

        //keep GameObject alive after remove scene
        public static void IsGlobal(GameObject gameObject)
        {
            Object.DontDestroyOnLoad(gameObject);
        }

    }

    //control program application
    public static class Program
    {
        //quit the game, shutdown the app
        public static void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        //Increase Graphic Quality Level for better Quality
        public static void IncreaseQualityLevel()
        {
            QualitySettings.IncreaseLevel(true);
        }

        //Decrease Graphic Quality Level for better perfomance
        public static void DecreaseQualityLevel()
        {
            QualitySettings.DecreaseLevel(true);
        }
        //set current Graphic Quality level
        public static void SetQualityLevel(int level)
        {
            QualitySettings.SetQualityLevel(level, true);
        }

        //get current Graphic Quality level
        public static int GetCurrentQualityLevel()
        {
            return QualitySettings.GetQualityLevel();
        }

        //Set AntiAliasing level value need to be 0, 2, 4 or 8
        public static void SetAntiAliasingLevel(int level)
        {
            QualitySettings.antiAliasing = level;
        }

        //Get AntiAliasing level
        public static int GetAntiAliasingLevel()
        {
            return QualitySettings.antiAliasing;
        }

        //set Vsync value need to be 0, 1, 2
        public static void SetVSyncCount(int count)
        {
            QualitySettings.vSyncCount = count;
        }
        //get Vsync count
        public static int SetVSyncCount()
        {
            return QualitySettings.vSyncCount;
        }
    }
    public static class Hightscore
    {
        public static int rank = -1;

        public static void AddToHightScore(float score)
        {
            rank = -1;
            if(PlayerDetails.hightScoreList.Count == 0)
            {
                PlayerDetails.hightScoreList.Add(score);
                rank = PlayerDetails.hightScoreList.Count;
            }
            else if(PlayerDetails.hightScoreList.Count < 5)
            {
                bool faster = false;
                for (int i = 0; i < PlayerDetails.hightScoreList.Count && !faster; i++)
                {
                    if (score < PlayerDetails.hightScoreList[i])
                    {
                        float temp = PlayerDetails.hightScoreList[i];
                        PlayerDetails.hightScoreList[i] = score;
                        PlayerDetails.hightScoreList.Add(temp);

                        //reorder
                        for (int k = i; k < PlayerDetails.hightScoreList.Count; k++)
                        {
                            for(int j = k; j< PlayerDetails.hightScoreList.Count;j++)
                            {
                                if(PlayerDetails.hightScoreList[j] <= PlayerDetails.hightScoreList[k])
                                {
                                    PlayerDetails.hightScoreList[k] = PlayerDetails.hightScoreList[j];
                                }
                            }
                        }

                        rank = i + 1;
                        faster = true;
                    }
                }
            }
            else if(PlayerDetails.hightScoreList.Count == 5)
            {
                for (int i = 0; i < PlayerDetails.hightScoreList.Count && rank == -1; i++)
                {
                    if(score < PlayerDetails.hightScoreList[i])
                    {
                        rank = i + 1;
                        PlayerDetails.hightScoreList[i] = score;
                    }
                }
            }
        }
    }
}
