using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControllerScript : MonoBehaviour
{
    //The audio mixer
    public AudioMixer mixer;

    

    //3 functions to set the master, music and effects volumes
    public void SetMasterLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("masterVolume", sliderValue);
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("musicVolume", sliderValue);
        mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }
    public void SetEffectsLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("effectsVolume", sliderValue);
        mixer.SetFloat("Effects", Mathf.Log10(sliderValue) * 20);
    }
}
