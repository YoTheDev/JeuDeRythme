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
    public GameObject Credits;

    public GameObject FirstSelectLvl;
    public GameObject FirstSelectCredits;
    public GameObject FirstSelectSettings;
    public GameObject FirstSelect;
    public Animator CamAnim;

    public EventSystem myEventSystem;

    void Start()
    {
        CamAnim.SetBool("AnimPos", false);
        Cursor.lockState = CursorLockMode.Locked;
        LvlSelect.SetActive(false);
        Menu.SetActive(true);
        Option.SetActive(false);
        Credits.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void CreditsButton()
    {
        CamAnim.SetBool("AnimPos", true);
        LvlSelect.SetActive(false);
        Menu.SetActive(false);
        Option.SetActive(false);
        Credits.SetActive(true);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelectCredits);
    }

    public void Settings()
    {
        CamAnim.SetBool("AnimPos", true);
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
        CamAnim.SetBool("AnimPos", true);
        LvlSelect.SetActive(true);
        Menu.SetActive(false);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelectLvl);
    }

    public void Back()
    {
        CamAnim.SetBool("AnimPos", false);
        Credits.SetActive(false);
        LvlSelect.SetActive(false);
        Menu.SetActive(true); 
        Option.SetActive(false);
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelect);
    }

}
