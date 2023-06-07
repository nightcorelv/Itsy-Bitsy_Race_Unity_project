using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
   
    private float pulse = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Core.Time.CountUpTime(ref pulse);
        Pulseing();

    }
    private void Pulseing()
    {
        if (pulse >= 2)
        {
            //scaleChange
            //Mathf.Lerp(transform.localScale.x, 1, 06, 0.5 * Time.deltaTime);//current scala, scala man vill ha, tiden skalar up
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 1.06f, 1f ), Mathf.Lerp(transform.localScale.y, 1.06f, 5f ), Mathf.Lerp(transform.localScale.z, 1.06f, 5f ));
            pulse = 0;
        }
        if (pulse >= 1)
        {
            //scaleChange
            //Mathf.Lerp(transform.localScale.x, 1, 06, 0.5 * Time.deltaTime);//current scala, scala man vill ha, tiden skalar up
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 1.0f, 1f ), Mathf.Lerp(transform.localScale.y, 1.0f, 5f ), Mathf.Lerp(transform.localScale.z, 1.0f, 5f ));

        }



    }
}
