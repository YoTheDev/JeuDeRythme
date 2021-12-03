using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Player;
    public ParticleSystem particules;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Player.GetComponent<PlayerProperties2>().ActionParade == false)
        {
            Player.GetComponent<PlayerProperties2>().PlayerDeath();
        }
        else
        {
            particules.Play();
            Destroy(this.gameObject);
        }
    }
}
