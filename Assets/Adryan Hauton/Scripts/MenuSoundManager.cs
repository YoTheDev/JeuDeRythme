using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuSoundManager : MonoBehaviour
{

    public AudioMixer Music;

    public void SetMusicVol(float sliderValue)
    {
        Music.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20); 
    }
}
