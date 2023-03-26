using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button optionsBtn;
    [SerializeField] private Button aboutBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button closeSettingsPanelBtn;
    [SerializeField] private Button closeAboutPanelBtn;
    
    
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject aboutPanel;

    
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
}
