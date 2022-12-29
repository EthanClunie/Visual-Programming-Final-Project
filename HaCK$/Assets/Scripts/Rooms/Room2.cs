using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    public PuzzleGoal Goal;
    public GameObject Block;

    private void OnLevelWasLoaded(int level)
    {
        if (Game.Instance.HasRoomBeenCleared(level))
        {
            Goal.gameObject.SetActive(false);
            Block.SetActive(false);
        }
    }
}
