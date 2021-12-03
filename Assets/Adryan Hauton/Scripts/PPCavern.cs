using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPCavern : MonoBehaviour
{

    public GameObject BasicPP;
    public GameObject CavernPP;

    private void Start()
    {
        BasicPP.SetActive(true);
        CavernPP.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PPInCavern();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BackToBasicPP();
        }
    }

    private void BackToBasicPP()
    {
        BasicPP.SetActive(true);
        CavernPP.SetActive(false);
    }

    private void PPInCavern()
    {
        BasicPP.SetActive(false);
        CavernPP.SetActive(true);
    }
}
