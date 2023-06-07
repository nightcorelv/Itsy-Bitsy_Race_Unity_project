using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCar : MonoBehaviour
{
    public GameObject zanniesCar;
    public GameObject liyesCar;
    public GameObject jocobsCar;

    public Button leftButton;
    public Button rightButton;

    void Start()
    {
        if (Core.PlayerDetails.playerSelectedCar==CarType.Jocob)
        {
            jocobsCar.SetActive(true);
            Transform body = jocobsCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
        else if(Core.PlayerDetails.playerSelectedCar == CarType.Liye)
        {
            liyesCar.SetActive(true);
            Transform body = liyesCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Zannie)
        {
            zanniesCar.SetActive(true);
            Transform body = zanniesCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
    }
    void Update()
    {
        if(Core.PlayerDetails.playerSelectedCar == CarType.Jocob || Core.PlayerDetails.playerSelectedCar == CarType.None)
        {
            leftButton.gameObject.SetActive(false);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Liye)
        {
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(true);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Zannie)
        {
            rightButton.gameObject.SetActive(false);
        }
    }
    public void left()
    {
        int i = (int)Core.PlayerDetails.playerSelectedCar;
        i--;
        Core.PlayerDetails.playerSelectedCar = (CarType)i;

        if (Core.PlayerDetails.playerSelectedCar == CarType.Jocob)
        {
            jocobsCar.SetActive(true);
            liyesCar.SetActive(false);
            zanniesCar.SetActive(false);
            Transform body = jocobsCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Liye)
        {
            liyesCar.SetActive(true);
            jocobsCar.SetActive(false);
            zanniesCar.SetActive(false);
            Transform body = liyesCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Zannie)
        {
            zanniesCar.SetActive(true);
            liyesCar.SetActive(false);
            jocobsCar.SetActive(false);
            Transform body = zanniesCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
    }
    public void right()
    {
        int i = (int)Core.PlayerDetails.playerSelectedCar;
        i++;
        Core.PlayerDetails.playerSelectedCar = (CarType)i;

        if (Core.PlayerDetails.playerSelectedCar == CarType.Jocob)
        {
            jocobsCar.SetActive(true);
            liyesCar.SetActive(false);
            zanniesCar.SetActive(false);
            Transform body = jocobsCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Liye)
        {
            liyesCar.SetActive(true);
            jocobsCar.SetActive(false);
            zanniesCar.SetActive(false);
            Transform body = liyesCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Zannie)
        {
            zanniesCar.SetActive(true);
            liyesCar.SetActive(false);
            jocobsCar.SetActive(false);
            Transform body = zanniesCar.transform.GetChild(0);
            body.localPosition = new Vector3(0, 0, 0);
        }
    }
}
