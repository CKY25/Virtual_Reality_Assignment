using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class showQuest : MonoBehaviour
{
    public GameObject questUI;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        DisplayQuestUI();
    }

    public void showQuestUI(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayQuestUI();
    }

    public void DisplayQuestUI()
    {
        if (isActive)
        {
            questUI.SetActive(false);
            isActive = false;

        }

        else if (!isActive)
        {
            questUI.SetActive(true);
            isActive = true;
        }
    }
}
