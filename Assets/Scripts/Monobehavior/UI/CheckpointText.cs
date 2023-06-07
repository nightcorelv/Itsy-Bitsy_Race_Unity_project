using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointText : MonoBehaviour
{
    public TMPro.TMP_Text text;
    float counter;
    private void Awake()
    {
        Core.CheckPoint.checkpointText = text;
    }
    private void Update()
    {
        if(text.gameObject.activeInHierarchy==true)
        {
            Core.Time.CountUpTime(ref counter);
            if(counter>=2)
            {
                counter = 0;
                text.gameObject.SetActive(false);
            }
        }
    }
}
