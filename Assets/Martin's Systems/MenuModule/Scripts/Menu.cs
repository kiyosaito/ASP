using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class Menu : MonoBehaviour
{
    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
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

    private void setupAspectRatio()
    {
        aspectRatioDropdown.ClearOptions();
        aspectRatios[0] = 4 / 3;
        aspectRatios[1] = 16 / 9;
        aspectRatios[2] = 16 / 10;
        List<string> options = new List<string>();

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
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIdx = 1;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIdx;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resIdx)
    {
        Resolution resolution = resolutions[resIdx];
        Screen.SetResolution(resolution.width, resolution.height,screenMode);
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

    public FullScreenMode getScreenMode()
    {
        return screenMode;
    }

    #endregion

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
