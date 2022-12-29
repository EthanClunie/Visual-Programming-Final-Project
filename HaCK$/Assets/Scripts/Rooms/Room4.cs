using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4 : MonoBehaviour
{
    public KillingPuzzle Puzzle;

    private void OnLevelWasLoaded(int level)
    {
        if (Game.Instance.HasRoomBeenCleared(level))
        {
            Destroy(Puzzle.gameObject);
        }
    }
}
