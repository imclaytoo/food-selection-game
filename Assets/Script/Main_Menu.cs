using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //Mulai Game
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    //Masuk menu About
    public void About()
    {
        Debug.Log("About");
    }
    
    //Keluar Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
