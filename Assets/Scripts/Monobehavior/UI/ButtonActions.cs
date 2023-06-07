using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonActions : MonoBehaviour
{


    public void goToScene(string name)
    {
        Core.Scene.OpenScene(name);
    }
    public void addScene(string name)
    {
        Core.Scene.AddScene(name);
    }
    public void quitGame()
    {
        Core.Program.QuitGame();
    }
    public void setQualityLevel(TMP_Dropdown dropdown)
    {
        Core.Program.SetQualityLevel(dropdown.value);
    }
    public void setVSyncCount(bool value)
    {
        if(value)
        {
            Core.Program.SetVSyncCount(1);
        }
        else
        {
            Core.Program.SetVSyncCount(0);
        }
    }
}
