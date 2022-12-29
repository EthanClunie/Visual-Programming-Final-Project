using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    public static GameOverState Instance;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup GameWinCanvasGroup;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        HideGameWin();
        HideGameOver();
        DontDestroyOnLoad(gameObject);
    }

    public void DisplayGameWin()
    {
        StartCoroutine(GradualGameWinDisplay(GameParameters.SecondsTillGameWinDisplay));
    }

    public void DisplayGameOver()
    {
        StartCoroutine(GradualGameOverDisplay(GameParameters.SecondsTillGameOverDisplay));
    }

    public void HideGameWin()
    {
        GameWinCanvasGroup.alpha = 0;
    }

    public void HideGameOver()
    {
        GameOverCanvasGroup.alpha = 0;
    }

    private IEnumerator GradualGameWinDisplay(float duration)
    {
        yield return new WaitForSeconds(duration);

        GameWinCanvasGroup.alpha = 1;
    }

    private IEnumerator GradualGameOverDisplay(float duration)
    {
        yield return new WaitForSeconds(duration);

        GameOverCanvasGroup.alpha = 1;
    }
}
