using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    Rigidbody carRigidbody;

    void Start()
    {
        carRigidbody = Core.PlayerDetails.playerCarBody.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, carRigidbody.velocity.magnitude * 4 * -1);
    }
}
