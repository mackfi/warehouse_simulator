using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupMenu : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
