using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    public static AudioSource MusicLVL;
    void Start()
    {
        MusicLVL = GetComponent<AudioSource>();
        Invoke("TimeForPlay", 3f);
    }
    
    void TimeForPlay()
    {
        MusicLVL.Play();
    }
}
