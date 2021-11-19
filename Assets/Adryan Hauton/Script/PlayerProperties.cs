using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;
using Object = UnityEngine.Object;

public class PlayerProperties : MonoBehaviour
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

    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded && isTime)
        {
            Debug.Log("hello");
            _rigidbody.AddForce(0, JumpPower, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Attaque
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Parade
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }

        if (other.gameObject.CompareTag("Spikes"))
        {
            PlayerDeath();
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
            transform.position = new Vector3(0f, 1.3f, TeleportDistance);
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
        Audio_manager.MusicLVL1.Stop();
        Death.Play();
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        Invoke("ReloadScene", 2.5f);
    }

    void ReloadScene()
    {
        LoadScene("SceneLvl1");
    }

}
