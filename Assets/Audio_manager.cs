using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    public static AudioSource MusicLVL1;
    void Start()
    {
        MusicLVL1 = GetComponent<AudioSource>();
        Invoke("TimeForPlay", 3f);
    }
    
    void TimeForPlay()
    {
        MusicLVL1.Play();
    }
}
