using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBox : MonoBehaviour
{

    public int nrOfCheckPointActivated = 0;

    private void Awake()
    {
        Core.CheckPoint.checkpointsList.Add(this);
    }
    private void Start()
    {
        nrOfCheckPointActivated = Core.CheckPoint.checkpointsList.IndexOf(this);
    }

    public void activateCheckpoint()
    {
        saveTime();
        Core.CheckPoint.currentCheckpointIndex++;
        Debug.Log(Core.CheckPoint.currentCheckpointIndex);
        Core.CheckPoint.checkpointText.gameObject.SetActive(true);
        Core.CheckPoint.checkpointsList.Remove(this);
        Destroy(this.gameObject);
    }

    public void saveTime()
    {
        transform.GetComponentInParent<CheckPointPosition>().checkPointEnterTime = Core.PlayerDetails.timeCounter.timeCounter;
    }

}
