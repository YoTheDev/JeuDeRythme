using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSoundManager : MonoBehaviour
{

    public AudioMixer Music;
    public Slider slider;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("CurrentVol");
    }

    public void SetMusicVol(float sliderValue)
    {
        Music.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("CurrentVol", slider.value);
    }
}
