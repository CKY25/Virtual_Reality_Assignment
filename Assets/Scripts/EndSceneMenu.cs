using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneMenu : MonoBehaviour
{
    public void RestartGame()
    {
        // Get the name of the scene to restart
        string lastScene = PlayerPrefs.GetString("LastScene");

        // Load that scene
        SceneManager.LoadScene(lastScene);
    }  
    public void QuitGame()
    {
      

        // Load that scene
        SceneManager.LoadScene(0);
    }    
    
    public void PlayAgain()
    {
      

        // BacktoLevel1
        SceneManager.LoadScene(1);
    }
}

