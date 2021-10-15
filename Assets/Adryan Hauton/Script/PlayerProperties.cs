using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerProperties : MonoBehaviour
{

    public float JumpPower;
    public LevelScrolling LevelScrolling;
    
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

    private void PlayerDeath()
    {
        Destroy(_mesh);
        // particules de destruction + son de mort + coupure de la musique + ReloadScene
        Destroy(this);
    }
}
