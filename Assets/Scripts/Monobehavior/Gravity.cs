using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public bool invertGravity;

    void Update()
    {
        if(invertGravity)
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
}
