using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class MenuManager : MonoBehaviour
{

    public GameObject LvlSelect;
    public GameObject Menu;
    public GameObject Option;
    private Vector3 CamOnSettings;
    private Vector3 CamOnMenu;
    public Camera cam;
    public GameObject Credits;

    public GameObject FirstSelectLvl;
    public GameObject FirstSelectCredits;
    public GameObject FirstSelectSettings;
    public GameObject FirstSelect;

    public EventSystem myEventSystem;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CamOnMenu = new Vector3(-44, 0, 0);
        CamOnSettings = new Vector3(44, 0, 0);
        LvlSelect.SetActive(false);
        Menu.SetActive(true);
        Option.SetActive(false);
        Credits.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void CreditsButton()
    {
        cam.transform.Translate(CamOnSettings);
        LvlSelect.SetActive(false);
        Menu.SetActive(false);
        Option.SetActive(false);
        Credits.SetActive(true);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelectCredits);
    }

    public void Settings()
    {
        cam.transform.Translate(CamOnSettings);
        LvlSelect.SetActive(false);
        Menu.SetActive(false);
        Option.SetActive(true);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelectSettings);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("SceneLvl1");
    }
    
    public void LoadScene2()
    {
        SceneManager.LoadScene("SceneLvl2");
    }
    
    public void LoadScene3()
    {
        SceneManager.LoadScene("SceneLvl3");
    }

    public void LevelSelect()
    {
        cam.transform.Translate(CamOnSettings);
        LvlSelect.SetActive(true);
        Menu.SetActive(false);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelectLvl);
    }

    public void Back()
    {
        Credits.SetActive(false);
        LvlSelect.SetActive(false);
        Menu.SetActive(true); 
        Option.SetActive(false);
        cam.transform.Translate(CamOnMenu);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelect);
    }

}
