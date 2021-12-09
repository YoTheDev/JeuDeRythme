using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagement : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public LevelScrolling LevelScrolling;
    public bool isPaused;

    private void Start()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            PauseMenu.SetActive(true);
            LevelScrolling._scrollingSpeed = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OpenSettings()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void Back()
    {
        PauseMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    public void Resume()
    {
        isPaused = false;
        LevelScrolling._scrollingSpeed = -0.02f;
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
