using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameState : MonoBehaviour
{
    public static PauseGameState Instance;
    public CanvasGroup PauseCanvasGroup;

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

        HidePauseText();
        DontDestroyOnLoad(gameObject);
    }

    public void DisplayPauseText()
    {
        PauseCanvasGroup.alpha = 1;
    }

    public void HidePauseText()
    {
        PauseCanvasGroup.alpha = 0;
    }

}
