using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggerBox : MonoBehaviour
{
    public float adjustLostSpeed = 0.5f;
    float normalMaxSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reduseSpeed()
    {
        //if (Core.PlayerDetails.player.GetComponent<SpeedBooster>() == null)// ska implementeras med speedBooster classen
        //{
            Core.PlayerDetails.speed /= adjustLostSpeed;
        Core.PlayerDetails.maxSpeed = adjustLostSpeed;
        ////}
        //else
        //{
        //    GetComponent<BoxCollider>().isTrigger = false;
        //}
    }
    public void setNormalSpeed()
    {
        Core.PlayerDetails.maxSpeed = normalMaxSpeed;
        //if (Core.PlayerDetails.player.GetComponent<SpeedBooster>()!= null)// ska implementeras med speedBooster classen
        //{
    //    GetComponent<BoxCollider>().isTrigger = true;
    ////}
}

  
}
