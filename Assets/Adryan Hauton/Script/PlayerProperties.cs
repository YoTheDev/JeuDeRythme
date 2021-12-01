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
    public bool isTimeForProjectile;
    public bool isTimeForAttack;
    public AudioSource Death;
    private Renderer rend;
    private GameObject projectile;
    public bool ActionParade;
    private GameObject enemy;
    public bool ActionAttack;

    void Start()
    {
        rend = GetComponent<Renderer>();
        _mesh = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        projectile = GameObject.Find("Projectile");
        enemy = GameObject.Find("Enemy");
        if (Input.GetKey(KeyCode.RightArrow) && isTimeForAttack && ActionAttack == false)
        {
            ActionAttack = true;
            Destroy(enemy.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isTimeForProjectile && ActionParade == false)
        {
            isTimeForProjectile = false;
            ActionParade = true;
            Invoke("FinParade",1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded && isTime)
        {
            _rigidbody.AddForce(0, JumpPower, 0, ForceMode.Impulse);
        }
    }

    void FinParade()
    {
        ActionParade = false;
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
        
        if(other.gameObject.CompareTag("Enemy"))
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
        }
        
        if (other.gameObject.CompareTag("EnemyCollider"))
        {
            isTimeForAttack = false;
        }
    }

    public void PlayerDeath()
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
        Scene scene = GetActiveScene();
        LoadScene(scene.name);
    }
}
