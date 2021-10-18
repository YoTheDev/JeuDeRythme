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
    
    [SerializeField]private bool _isGrounded = false;
    private Rigidbody _rigidbody;
    private MeshRenderer _mesh;

    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
        {
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
            transform.position = new Vector3(0f, 1.3f, 20f);
        }
        
        if (other.gameObject.CompareTag("Spikes"))
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        Destroy(_mesh);
        LevelScrolling._scrollingSpeed = 0f;
        Particles.Play();
        // particules de destruction + son de mort + coupure de la musique + ReloadScene
        Invoke("ReloadScene", 1f);
    }

    void ReloadScene()
    {
        LoadScene("AdryanH");
    }

}
