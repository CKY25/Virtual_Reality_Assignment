using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{
    public GameObject wrisUI;
    public bool activeWrisUI = true;

    // Start is called before the first frame update
    void Start()
    {
        DisplayWrisUI();
    }


    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
            DisplayWrisUI();
        Debug.Log("Yes");
        
    } 
    public void DisplayWrisUI()
    {
        if(activeWrisUI)
        {
            wrisUI.SetActive(false);
            activeWrisUI = false;
            Time.timeScale = 1.0f;

        } 
        
        else if(!activeWrisUI)
        {
            wrisUI.SetActive(true);
            activeWrisUI = true;
            Time.timeScale = 0;
        } 
    }

    public void RestartGame()
    {

        wrisUI.SetActive(false);
        activeWrisUI = false;
        Time.timeScale = 1.0f;
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Debug.Log("Exit");
    }
}
