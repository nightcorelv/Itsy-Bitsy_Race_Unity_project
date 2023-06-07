using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPosition : MonoBehaviour
{
    public GameObject checkPointPrefab;
    public int index;
    public float checkPointEnterTime;
    public bool checkPointTrigged;

    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint3;
    public GameObject checkpoint4;

    void Start()
    {
        Core.CheckPoint.checkPointTransform.Add(this);
    }
    private void Update()
    {
        if (Core.PlayerDetails.currentlapNumber == 0)
        {
            if (checkpoint1 != null)
            {
                checkpoint1.gameObject.SetActive(true);
            }
        }
        else if (Core.PlayerDetails.currentlapNumber == 1)
        {
            //checkpoint1.gameObject.SetActive(false);
            if(checkpoint2!=null)
            {
                checkpoint2.gameObject.SetActive(true);
            }
            //checkpoint3.gameObject.SetActive(false);

        }
        else if (Core.PlayerDetails.currentlapNumber == 2)
        {
            //checkpoint1.gameObject.SetActive(false);
            //checkpoint2.gameObject.SetActive(false);
            if (checkpoint3 != null)
            {
                checkpoint3.gameObject.SetActive(true);
            }
        }
        else if (Core.PlayerDetails.currentlapNumber == 3)
        {
            //checkpoint1.gameObject.SetActive(false);
            //checkpoint2.gameObject.SetActive(false);
            if (checkpoint4 != null)
            {
                checkpoint4.gameObject.SetActive(true);
            }
        }
    }
    public void ResetCheckPoint()
    {
        //var go = GameObject.Instantiate(checkPointPrefab);
        //go.transform.SetParent(this.transform);
        //go.transform.localPosition = default;
        //go.transform.localRotation = default;
        //go.transform.localScale = new Vector3(1, 1, 1);


    }
}
