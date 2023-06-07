using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paus : MonoBehaviour
{

    public static bool IsPaused = false;

    public GameObject pauseMenuCanvas;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button7))
        {
            if (IsPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }

    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }


    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()
    {
        Core.Program.QuitGame();
    }
}
