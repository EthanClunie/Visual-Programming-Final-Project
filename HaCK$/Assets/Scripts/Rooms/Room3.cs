using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour
{
    public KonamiCodePuzzle Puzzle;

    private void OnLevelWasLoaded(int level)
    {
        if (Game.Instance.HasRoomBeenCleared(level))
        {
            Puzzle.gameObject.SetActive(false);
        }
    }
}
