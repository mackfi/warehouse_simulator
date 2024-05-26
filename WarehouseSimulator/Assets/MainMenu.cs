using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void OptionsClicked()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }
}
