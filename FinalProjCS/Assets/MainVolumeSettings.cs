using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainVolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    

    private void Start()
    {
        LoadVolumes(); // Load audio volumes when the options menu starts
    }

    private void OnDisable()
    {
        SaveVolumes(); // Save audio volumes when the options menu is disabled (e.g., when returning to the game)
    }

    private void SetDefaultVolumes()
    {
        
        musicSlider.value = 0.1f;
    

        SaveVolumes();
    }

    private void LoadVolumes()
    {
        
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.1f);
        SetVolume("Music", musicSlider);
        
    }

    private void SaveVolumes()
    {
        
        SetVolume("Music", musicSlider);
    }

    private void SetVolume(string name, Slider slider)
    {
        PlayerPrefs.SetFloat(name, slider.value);

        float volume = Mathf.Log10(slider.value) * 20;
        if (slider.value == 0)
        {
            volume = -80;
        }
        mixer.SetFloat(name, volume);
    }

    public void SetMusicVolume()
    {
        SetVolume("Music", musicSlider);
    }

    private void OnApplicationQuit()
    {
        SaveVolumes(); // Save volumes when the application is quitting
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveVolumes(); // Save volumes when the application is paused (e.g., when going to the home screen on a mobile device)
        }
    }

    private void OnDestroy()
    {
        SaveVolumes(); // Save volumes when the script or GameObject is being destroyed
    }
}

