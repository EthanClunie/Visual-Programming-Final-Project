using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    public MazeGoal Goal;

    private void OnLevelWasLoaded(int level)
    {
        if (Game.Instance.HasRoomBeenCleared(level))
        {
            print(level);
            Goal.gameObject.SetActive(false);
        }
    }

}
