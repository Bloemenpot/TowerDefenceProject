using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Pause();

        if (!GameManager.isPaused)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }
}
