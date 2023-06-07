using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvents : MonoBehaviour
{
    [System.Serializable]
    public class CollisionEnterEvent : UnityEvent { };
    [System.Serializable]
    public class CollisionExitEvent : UnityEvent { };
    [System.Serializable]
    public class CollisionStayEvent : UnityEvent { };

    [SerializeField]
    public CollisionEnterEvent collisionEnter;
    [SerializeField]
    public CollisionEnterEvent collisionExit;
    [SerializeField]
    public CollisionEnterEvent collisionStay;

    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        collisionEnter.Invoke();
    }
    private void OnCollisionExit(Collision collision)
    {
        collisionExit.Invoke();
    }
    private void OnCollisionStay(Collision collision)
    {
        collisionStay.Invoke();
    }
}
