using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidWater : MonoBehaviour
{
  
    private MeshCollider solidWater;
    // Start is called before the first frame update
    void Start()
    {
        solidWater = this.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Booster speedBoosterActive in Core.PlayerDetails.boosters)
        {
            if(speedBoosterActive.typeOfBooster== BoosterType.SpeedBoster)
            {
                makeSolidWater();
            }
        }
        if(Core.PlayerDetails.SpeedBoosterOn == false)
        {

            solidWater.enabled = false;
        }
    }

    public void makeSolidWater()
    {
        solidWater.enabled = true;
        Core.PlayerDetails.SpeedBoosterOn = true;

    }
}
