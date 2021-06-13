using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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

    #region Quit
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game Quitting");
    }
    #endregion
}
