using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;
using Object = UnityEngine.Object;

public class PlayerProperties2 : MonoBehaviour
{
    public float JumpPower;
    public LevelScrolling LevelScrolling;
    public ParticleSystem Particles;
    public float TeleportDistance;

    [SerializeField]private bool _isGrounded = false;
    private Rigidbody _rigidbody;
    private MeshRenderer _mesh;
    public bool isTime = false;
    public AudioSource Death;

    public GameObject Terrain;
    public AudioSource musiclvl;

    public GameObject PauseUI;
    public float lvlSpeed;

    public Camera cam;
    private bool inUI = false;

    public bool isTimeForProjectile;
    public bool isTimeForAttack;
    private GameObject enemy;
    public bool ActionAttack;
    private GameObject projectile;
    public bool ActionParade;
    private bool isDead;



    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseUI.SetActive(false);
    }

    void Update()
    {
        projectile = GameObject.Find("Projectile");
        enemy = GameObject.FindWithTag("Enemy");

        if (Input.GetKey(KeyCode.RightArrow) && isTimeForAttack && ActionAttack == false && isDead == false) 
        {
            Destroy(enemy.gameObject);
            isTimeForAttack = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isTimeForProjectile && ActionParade == false && isDead == false)
        {
            isTimeForProjectile = false;
            ActionParade = true;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded && isTime && isDead == false)
        {
            _rigidbody.AddForce(0, JumpPower, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !inUI && isDead == false)
        {
            inUI = true;
            LevelScrolling._scrollingSpeed = 0f;
            musiclvl.Pause();
            Death.Pause();
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && inUI)
            {
                Resume();
            }
        }
    }


    public void Resume()
    {
        inUI = false;
        musiclvl.Play();
        Death.Play();
        LevelScrolling._scrollingSpeed = -lvlSpeed;
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            transform.position = new Vector3(242f, 25f, TeleportDistance);
            cam.fieldOfView = 40f;
        }

        if (other.gameObject.CompareTag("Portal2"))
        {
            transform.position = new Vector3(242f, 3f, 37f);
            cam.fieldOfView = 35f;
        }

        if (other.gameObject.CompareTag("FrontOfOb"))
        {
            isTime = true;
        }
        
        if (other.gameObject.CompareTag("Spikes"))
        {
            PlayerDeath();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath();
        }

        if (other.gameObject.CompareTag("ProjectileActionZone"))
        {
            isTimeForProjectile = true;
        }

        if (other.gameObject.CompareTag("EnemyCollider"))
        {
            isTimeForAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FrontOfOb"))
        {
            isTime = false;
        }

        if (other.gameObject.CompareTag("ProjectileActionZone"))
        {
            isTimeForProjectile = false;
            ActionParade = false;
        }

        if (other.gameObject.CompareTag("EnemyCollider"))
        {
            isTimeForAttack = false;
            ActionAttack = false;
        }
    }

    public void PlayerDeath()
    {
        isDead = true;
        Destroy(_mesh);
        LevelScrolling._scrollingSpeed = 0f;
        Particles.Play();
        musiclvl.Stop();
        Death.Play();
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        Invoke("ReloadScene", 1);
    }

    void ReloadScene()
    {
        Scene scene = GetActiveScene();
        LoadScene(scene.name);
    }

}
