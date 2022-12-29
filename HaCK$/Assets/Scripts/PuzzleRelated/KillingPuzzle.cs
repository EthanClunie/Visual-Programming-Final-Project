using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingPuzzle : MonoBehaviour
{
    public Enemies Enemies;

    void Update()
    {
        if (Enemies.AllAreDead())
        {
            MarkPuzzleAsSolved();
            Destroy(this.gameObject);
        }
    }

    private void MarkPuzzleAsSolved()
    {
        print("All enemies vanquished");
        Game.Instance.RoomCompleted();
    }

    private void OnDestroy()
    {
        Destroy(Enemies.gameObject);
    }
}
