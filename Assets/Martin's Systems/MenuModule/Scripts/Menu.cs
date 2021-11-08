using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Menu : MonoBehaviour
{
    #region Monobehaviour  
    // Start is called before the first frame update
    void Start()
    {
        SetupAspectRatio();
        Gameobjectstarting();
        GetResolutions();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Menu start up
    [Header("Starting objects")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject settingsContent;
    [SerializeField]
    private GameObject graphics;
    [SerializeField]
    private GameObject Audio;
    [SerializeField]
    private GameObject Controls;

    private void Gameobjectstarting()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        settingsContent.SetActive(true);
        graphics.SetActive(false);
        Audio.SetActive(false);
        Controls.SetActive(false);
    }

    #endregion

    #region Play
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Load game");
    }
    #endregion

    #region Settings

    #region Graphics

    #region Aspect Ratio

    [Header("Graphics")]
    [SerializeField]
    private TMP_Dropdown aspectRatioDropdown;
    private float[] aspectRatios = new float[3];
    private string[] aspectRatiosString = new string[3];
    float aspectRatio = 0.0f;

    private void SetupAspectRatio()
    {
        
        aspectRatio = (float)(Mathf.Round(((float)Screen.width) / ((float)Screen.height) * 100f) * 0.01f);

        aspectRatioDropdown.ClearOptions();
        aspectRatios[0] = (float)(Mathf.Round(((float)4) / ((float)3)*100f)*0.01f);
        aspectRatios[1] = (float)(Mathf.Round(((float)16) / ((float)9)*100f)*0.01f);
        aspectRatios[2] = (float)(Mathf.Round(((float)16) / ((float)10)* 100f)*0.01f);

        aspectRatioDropdown.ClearOptions();
        aspectRatiosString[0] = "4:3";
        aspectRatiosString[1] = "16:9";
        aspectRatiosString[2] = "16:10";

        List<string> options = new List<string>();
        int curASI =0 ;
        for (int i=0;i<aspectRatios.Length;i++)
        {
            options.Add(aspectRatiosString[i]);
            if (aspectRatios[i] == aspectRatio)
            {
                curASI = 1;
            }
        }
        aspectRatioDropdown.AddOptions(options);
        aspectRatioDropdown.value = curASI;
        aspectRatioDropdown.RefreshShownValue();
        
    }
    public void SetAspectRatio(int ARI)
    {
        aspectRatio = aspectRatios[ARI];
        GetResolutions();
    }
    #endregion

    #region Resolution
    [SerializeField]
    private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void GetResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResIdx = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if ((float)(Mathf.Round(((float)resolutions[i].width) / ((float)resolutions[i].height) * 100f) * 0.01f) == aspectRatio)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResIdx = 1;
                }
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIdx;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIdx)
    {
        Screen.SetResolution(resolutions[resIdx].width, resolutions[resIdx].height, screenMode);
    }

    #endregion

    #region Quality

    [SerializeField]
    private TMP_Dropdown qualityLevelDropdown;

    public void SetQuality(int idx)
    {
        qualityLevelDropdown.value = idx;
        QualitySettings.SetQualityLevel(qualityLevelDropdown.value);
    }

    #endregion

    #region Screen Mode

    [SerializeField]
    private TMP_Dropdown screenModeDropdown;
    [SerializeField]
    private FullScreenMode[] screenModeArray = new FullScreenMode[3];
    private FullScreenMode screenMode;

    public void SetWindowMode(int idx)
    {
        screenModeDropdown.value = idx;
        screenMode = screenModeArray[screenModeDropdown.value];
        Screen.fullScreenMode = screenMode;
    }

    public FullScreenMode GetScreenMode()
    {
        return screenMode;
    }

    #endregion

    #endregion

    #region Audio
    [Header("Audio")]
    public AudioMixer audioMixer;
    public void SetMainVolume(float input)
    {
        audioMixer.SetFloat("MainVol", input);
    }

    public void SetSFXVolume(float input)
    {
        audioMixer.SetFloat("SFXVol", input);
    }

    public void SetMusicVolume(float input)
    {
        audioMixer.SetFloat("MusicVol", input);
    }

    public void SetDialogueVolume(float input)
    {
        audioMixer.SetFloat("DialogueVol", input);
    }

    #endregion

    #endregion

    #region Quit
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game Quitting");
    }
    #endregion
}
