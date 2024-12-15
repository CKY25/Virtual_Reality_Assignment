using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLvl : MonoBehaviour
{
    public GameObject finishUI;

    // Start is called before the first frame update
    void Start()
    {
        finishUI.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            finishUI.SetActive(true);
            Time.timeScale = 0.0f;
            this.gameObject.SetActive(false);
        }
    }

    public void loadLvl(int level)
    {    
        SceneManager.LoadScene(level);
        Time.timeScale = 1.0f;
    }

    public void endGame()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }
}
