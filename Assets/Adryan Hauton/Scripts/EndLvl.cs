using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{

    public GameObject EndUI;
    public LevelScrolling Scroller;
    public GameObject player;
    public Animator CamAnimator;
    public EventSystem myEventSystem;
    public GameObject FirstSelectEndUI;

    void Start()
    {
        EndUI.SetActive(false);
        player.GetComponent<SpriteRenderer>();
        player.GetComponent<PlayerProperties2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EndThisLvl();
        }
    }

    void EndThisLvl()
    {
        Scroller._scrollingSpeed = 0;
        CamAnimator.SetBool("End", true);
        EndUI.SetActive(true);
        Destroy(player.GetComponent<SpriteRenderer>());
        Destroy(player.GetComponent<PlayerProperties2>());
        Audio_manager.MusicLVL.Pause();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelectEndUI);
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NextLvl1()
    {
        SceneManager.LoadScene("SceneLvl2");
    }

    public void NextLvl2()
    {
        SceneManager.LoadScene("Scenelvl3");
    }

}
