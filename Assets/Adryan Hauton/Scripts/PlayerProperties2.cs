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
    public GameObject cube;
    public AudioSource musiclvl;

    public GameObject PauseUI;
    private bool inUI = false;
    public float lvlSpeed;

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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // attaque
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           // parade
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded && isTime)
        {
            _rigidbody.AddForce(0, JumpPower, 0, ForceMode.Impulse);

            GameObject cubeObj = Instantiate(cube, transform.position, transform.rotation);
            cubeObj.transform.parent = Terrain.transform;
        }

        if (Input.GetKey(KeyCode.Escape) && !inUI)
        {
            inUI = true;
            LevelScrolling._scrollingSpeed = 0f;
            musiclvl.Pause();
            PauseUI.SetActive(true);
        }
    }


    public void Resume()
    {
        inUI = false;
        musiclvl.Play();
        LevelScrolling._scrollingSpeed = -lvlSpeed;
        PauseUI.SetActive(false);
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
        }

        if (other.gameObject.CompareTag("FrontOfOb"))
        {
            isTime = true;
        }
        
        if (other.gameObject.CompareTag("Spikes"))
        {
            PlayerDeath();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FrontOfOb"))
        {
            isTime = false;
        }
    }

    void PlayerDeath()
    {
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
