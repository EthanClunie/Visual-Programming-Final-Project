using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGoal : MonoBehaviour
{
    private bool isSolved = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && !isSolved)
        {
            MarkPuzzleAsSolved();
            gameObject.SetActive(false);
        }
    }

    private void MarkPuzzleAsSolved()
    {
        print("Maze solved");
        Game.Instance.RoomCompleted();
        isSolved = true;
    }
}
