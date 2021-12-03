using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileZone : MonoBehaviour
{
    public GameObject projectile;
    public float ProjectileSpeed;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            projectile.transform.Translate(Vector3.down * ProjectileSpeed * Time.deltaTime);
        }
    }
}
