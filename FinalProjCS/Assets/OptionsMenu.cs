using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public Toggle vsync;
    public Toggle fullscreenToggle;
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider FXVolume;
    // Start is called before the first frame update
    public void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        foreach(Resolution resolution in resolutions){
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSetting();
    }
    
    public void ApplySetting(){
        Resolution selectedResolution = Screen.resolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullscreenToggle.isOn);

        QualitySettings.vSyncCount = vsync.isOn ? 1 : 0;
        Screen.fullScreen = fullscreenToggle.isOn;
        AudioListener.volume = masterVolume.value;
    }

    public void SaveSetting(){
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("Vsync", vsync.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("Master Volume", masterVolume.value);
        PlayerPrefs.SetFloat("Music Volume", musicVolume.value);
        PlayerPrefs.SetFloat("FX Volume", FXVolume.value);
        PlayerPrefs.Save();
    }

    public void LoadSetting(){
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", 0);
        vsync.isOn = PlayerPrefs.GetInt("Vsync", 1) == 1;
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        masterVolume.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        FXVolume.value = PlayerPrefs.GetFloat("FXVolume", 1.0f);

        ApplySetting();
    }

    public void OnBackButtonClick()
    {
        SaveSetting(); // Save settings before going back to the main menu
    // Load the main menu scene. Adjust the scene name based on your actual scene name.
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("HELP");
        
    }
    
}
