using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;


public class StartScreen : MonoBehaviour
{
    
    [Header("Start Menu Buttons")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button optionsBtn;
    [SerializeField] private Button aboutBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button closeSettingsPanelBtn;
    [SerializeField] private Button closeAboutPanelBtn;
    [Header("Menu Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject aboutPanel;
    [Header("Settings Menu Relevant")] 
    [SerializeField] private Resolution[] _screenResolutions;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private float currentVolume;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private int _currentResIndex;
    
    private void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        optionsBtn.onClick.AddListener(ShowSettingsPanel);
        aboutBtn.onClick.AddListener(ShowAboutPanel);
        quitBtn.onClick.AddListener(CloseGame);
        closeAboutPanelBtn.onClick.AddListener(CloseAllPanels);
        closeSettingsPanelBtn.onClick.AddListener(CloseAllPanels);

        aboutPanel.SetActive(false);
        settingsPanel.SetActive(false);
        
        
        InitializeResolutionSettings();
        LoadSettings(_currentResIndex);

    }

    private static void StartGame()
    {
        // change to main scene + async later
        SceneManager.LoadScene("Scenes/Charlie");
        
    }

    private void CloseGame()
    {
        switch (Application.platform)
        {

#if UNITY_EDITOR
        case RuntimePlatform.WindowsEditor:
            EditorApplication.ExitPlaymode();
            break;
#endif
        
        case RuntimePlatform.WindowsPlayer:
            Application.Quit();
            break;
        default:
            throw new ArgumentOutOfRangeException();
        }
    }

    private void ShowAboutPanel()
    {
        ToggleButtonInteractivity(false);
        if (!CheckIfCanSelectButtons()) return;
        CloseAllPanels();
        aboutPanel.SetActive(true);
    }

    private void ShowSettingsPanel()
    {
        ToggleButtonInteractivity(false);
        if (!CheckIfCanSelectButtons()) return;
        CloseAllPanels();
        settingsPanel.SetActive(true);
    }

    private void CloseAllPanels()
    {
        settingsPanel.SetActive(false);
        aboutPanel.SetActive(false);
        ToggleButtonInteractivity(true);
    }

    private void ToggleButtonInteractivity(bool yn)
    {
        startBtn.interactable = yn;
        optionsBtn.interactable = yn;
        aboutBtn.interactable = yn;
        quitBtn.interactable = yn;
    }
    
    private bool CheckIfCanSelectButtons()
    {
        return !(settingsPanel.activeSelf || aboutPanel.activeSelf);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _screenResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("FullScreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
    }

    public void LoadSettings(int currentResIndex)
    {
        Screen.fullScreen = PlayerPrefs.HasKey("FullScreenPreference") && Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : currentResIndex;
        volumeSlider.value = PlayerPrefs.HasKey("VolumePreference") ? PlayerPrefs.GetFloat("VolumePreference") : 1f;
    }

    private void InitializeResolutionSettings()
    {
        resolutionDropdown.ClearOptions();
        var options = new List<string>();
        _screenResolutions = Screen.resolutions;
        for (var i = 0; i < _screenResolutions.Length; i++)
        {
            var option = _screenResolutions[i].width + " x " + _screenResolutions[i].height;
            options.Add(option);
            if (_screenResolutions[i].width == Screen.currentResolution.width && _screenResolutions[i].height == Screen.currentResolution.height)
            {
                _currentResIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
    }
    
    
}
