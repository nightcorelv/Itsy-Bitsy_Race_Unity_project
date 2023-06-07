using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public GameObject playerIcon;
    public GameObject minimap;
    public Camera miniMapCamera;

    void Start()
    {
        playerIcon.SetActive(true);
        minimap.SetActive(true);
        miniMapCamera.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        playerIcon.transform.position = new Vector3(Core.PlayerDetails.playerCarBody.transform.position.x, playerIcon.transform.position.y, Core.PlayerDetails.playerCarBody.transform.position.z);
    }
}
