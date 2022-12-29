using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainHub");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
