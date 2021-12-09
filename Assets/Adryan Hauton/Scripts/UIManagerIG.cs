using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManagerIG : MonoBehaviour
{
    public GameObject Validation;
    public GameObject PauseUI;
    public GameObject SettingsUI;

    public AudioMixer Music;

    public GameObject FirstSelectPause;
    public GameObject FirstSelectSettings;
    public GameObject FirstSelectValidation;

    public EventSystem myEventSystem;
    private float MusicVolume;
    public Slider slider;


    void Start()
    {
        Validation.SetActive(false);
        PauseUI.SetActive(false);
        SettingsUI.SetActive(false);
        SetSlider();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("AlphaMenu");
    }

    public void Quit()
    {
        Validation.SetActive(true);
        PauseUI.SetActive(false);
        SettingsUI.SetActive(false);
        myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(FirstSelectValidation);
    }

    public void Validate()
    {
        Application.Quit();
    }

    public void Settings()
    {
        Validation.SetActive(false);
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
        myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(FirstSelectSettings);
    }


    public void Back()
    {
        Validation.SetActive(false);
        PauseUI.SetActive(true);
        SettingsUI.SetActive(false);
        myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(FirstSelectPause);
    }
    
    public void SetMusicVol(float sliderValue)
    {
        Music.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("CurrentVol", slider.value);
    }


    public void SetSlider()
    {
        slider.value = PlayerPrefs.GetFloat("CurrentVol");
    }
}
