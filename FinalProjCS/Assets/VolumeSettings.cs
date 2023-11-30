using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

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
        masterSlider.value = 0.1f;
        musicSlider.value = 0.1f;
        sfxSlider.value = 0.1f;

        SaveVolumes();
    }

    private void LoadVolumes()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master", 0.1f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0.1f);

        SetVolume("Master", masterSlider);
        SetVolume("Music", musicSlider);
        SetVolume("SFX", sfxSlider);
    }

    private void SaveVolumes()
    {
        SetVolume("Master", masterSlider);
        SetVolume("Music", musicSlider);
        SetVolume("SFX", sfxSlider);
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

    public void SetMasterVolume()
    {
        SetVolume("Master", masterSlider);
    }

    public void SetSFXVolume()
    {
        SetVolume("SFX", sfxSlider);
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
