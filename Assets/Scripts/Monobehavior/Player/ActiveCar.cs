using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCar : MonoBehaviour
{
    public CarType selectedCar;
    GameObject jacobCar;
    GameObject liyeCar;
    GameObject zannieCar;

    void Awake()
    {
        jacobCar = this.transform.Find("JocobsGarbageCar").gameObject;
        liyeCar = this.transform.Find("LiyesGarbageCar").gameObject;
        zannieCar = this.transform.Find("ZanniesGarbageCar").gameObject;

        jacobCar.SetActive(false);
        liyeCar.SetActive(false);
        zannieCar.SetActive(false);

        Player[] cars = GameObject.Find("Cars").transform.GetComponentsInChildren<Player>(true);

        if(selectedCar != CarType.None)
        {
            Core.PlayerDetails.playerSelectedCar = selectedCar;
        }

        if (Core.PlayerDetails.playerSelectedCar == CarType.Jocob)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].gameObject.name.Contains("Jocob"))
                {
                    cars[i].gameObject.SetActive(true);
                }
            }

        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Liye)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].gameObject.name.Contains("Liye"))
                {
                    cars[i].gameObject.SetActive(true);
                }
            }
        }
        else if (Core.PlayerDetails.playerSelectedCar == CarType.Zannie)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].gameObject.name.Contains("Zannie"))
                {
                    cars[i].gameObject.SetActive(true);
                }
            }

        }
    }

}
