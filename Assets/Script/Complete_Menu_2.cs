using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete_Menu_2 : MonoBehaviour
{
    //Balik ke main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    //Keluar game
    public void QuitGame()
    {
        Application.Quit();
    }
}