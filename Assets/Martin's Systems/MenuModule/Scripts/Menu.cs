using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class Menu : MonoBehaviour
{
    #region Variables

    //private TMPro.TMP_Dropdown screenModedropdown;
    private FullScreenMode[] screenMode = new FullScreenMode[3];

    #endregion

    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetWindowMode(int windowModeIndex)
    {
        Screen.fullScreenMode = screenMode[windowModeIndex];
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
