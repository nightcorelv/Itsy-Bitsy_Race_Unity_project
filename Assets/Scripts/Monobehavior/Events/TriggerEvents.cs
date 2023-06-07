using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class TriggerEvents : MonoBehaviour
{
    [System.Serializable]
    public class TriggerEnterEvent : UnityEvent { };
    [System.Serializable]
    public class TriggerExitEvent : UnityEvent { };
    [System.Serializable]
    public class TriggerStayEvent : UnityEvent { };

    //Collider collider;

    [SerializeField]
    TriggerEnterEvent triggerEnter;
    [SerializeField]
    TriggerExitEvent triggerExit;
    [SerializeField]
    TriggerStayEvent triggerStay;



    void Start()
    {
        //collider = GetComponentInChildren<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        triggerEnter.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        triggerExit.Invoke();
    }
    private void OnTriggerStay(Collider other)
    {
        triggerStay.Invoke();
    }
}
