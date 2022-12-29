using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public void LoadHubRoom()
    {
        SceneManager.LoadScene(GameParameters.HubRoomSceneName);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(GameParameters.GameOverSceneName);
    }

    public void LoadRoom(string roomToLoad)
    {
        SceneManager.LoadScene(roomToLoad);
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public int GetCurrentSceneNumber()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
