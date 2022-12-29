using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public Player Player;
    public Teleporter TP1;
    public Teleporter TP3;
    public Teleporter TP4;
    public Teleporter TP5;

    private bool isGamePaused = false;

    private short numRoomsCompleted;
    private string lastRoomCompleted;
    private bool isR1Cleared = false;
    private bool isR2Cleared = false;
    private bool isR3Cleared = false;
    private bool isR4Cleared = false;
    private bool isR5Cleared = false;

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

        numRoomsCompleted = 0;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LockPortals();
    }

    private void Update()
    {
        if (Player.IsPlayerDead())
        {
            GameOver();
        }
    }

    public void RoomCompleted()
    {
        ++numRoomsCompleted;
        lastRoomCompleted = SceneHandler.Instance.GetCurrentSceneName();
        RewardCompletion();
    }

    public bool HasRoomBeenCleared(int level)
    {
        bool isCleared = false;

        if (level == 2)
        {
            isCleared = isR1Cleared;
        }
        else if (level == 3)
        {
            isCleared = isR2Cleared;
        }
        else if (level == 4)
        {
            isCleared = isR3Cleared;
        }
        else if (level == 5)
        {
            isCleared = isR4Cleared;
        }

        return isCleared;
    }

    public int GetNumRoomsCompleted()
    {
        return numRoomsCompleted;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        PauseGameState.Instance.DisplayPauseText();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        PauseGameState.Instance.HidePauseText();
    }

    public bool IsGamePaused()
    {
        return isGamePaused;
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void GameWin()
    {
        StartCoroutine(TimedGameWin());
    }

    private void GameOver()
    {
        StartCoroutine(TimedGameOver());
    }

    public IEnumerator TimedGameWin()
    {
        GameOverState.Instance.DisplayGameWin();

        yield return new WaitForSeconds(GameParameters.SecondsTillGameWinDisplay);

        Destroy(Player.gameObject);
        DisableGameplay();
    }

    private IEnumerator TimedGameOver()
    {
        GameOverState.Instance.DisplayGameOver();

        yield return new WaitForSeconds(GameParameters.SecondsTillGameOverDisplay + 1.0f);

        Player.PlayerDeath();
        Destroy(Boss.Instance.gameObject);
        DisableGameplay();
    }

    private void DisableGameplay()
    {
        ToggleShooting();
        Time.timeScale = 0;
        isGamePaused = true;
    }

    private void RewardCompletion()
    {
        if (lastRoomCompleted == "Room1")         // Maze
        {
            if (!isR1Cleared)
            {
                ScreenShakeStandard();
                isR1Cleared = true;
            }

        }
        else if ((lastRoomCompleted == "Room2"))  // Block pushing
        {
            if (!isR2Cleared)
            {
                UnlockPortals();
                ScreenShakeStandard();
                ToggleShooting();
                isR2Cleared = true;
            }

        }
        else if (lastRoomCompleted == "Room3")    // Konami Code
        {
            if (!isR3Cleared)
            {
                ScreenShakeStandard();
                UnlockSprint();
                isR3Cleared = true;
            }

        }
        else if (lastRoomCompleted == "Room4")    // Shooting room
        {
            if (!isR4Cleared)
            {
                ScreenShakeStandard();
                // Give hint for Konami code puzzle

                isR4Cleared = true;
            }

        }
        else if (lastRoomCompleted == "Room5")    // Boss room
        {
            if (!isR5Cleared)
            {
                ScreenShakeBoss();
                GameWin();
                isR5Cleared = true;
            }

        }
    }

    private void ToggleShooting()
    {
        PlayerWeapon.Instance.ToggleShooting();
    }

    private void UnlockSprint()
    {
        PlayerController2D.Instance.UnlockSprint();
    }

    private void LockPortals()
    {
        TP1.LockPortal();
        TP3.LockPortal();
        TP4.LockPortal();
        TP5.LockPortal();
    }

    private void UnlockPortals()
    {
        TP1.UnlockPortal();
        TP3.UnlockPortal();
        TP4.UnlockPortal();
        TP5.UnlockPortal();
    }

    private void ScreenShakeStandard()
    {
        CameraShake.Shake(GameParameters.ScreenShakeDuration, GameParameters.ScreenShakeMagnitude);
    }

    private void ScreenShakeBoss()
    {
        CameraShake.Shake(GameParameters.ScreenShakeDuration * 1.5f, GameParameters.ScreenShakeMagnitude * 1.2f);
    }

}
