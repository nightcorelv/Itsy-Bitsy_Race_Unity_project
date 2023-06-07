using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandom : MonoBehaviour
{
    public List<Sprite> alternativeSprites;

    void Start()
    {
        int randomNr = Random.Range(0, alternativeSprites.Count);
        this.GetComponent<UnityEngine.UI.Image>().sprite = alternativeSprites[randomNr];
    }

}
