using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGoal : MonoBehaviour
{
    public GameObject MatchingBlock;

    private Rigidbody BlockRigidBody;
    private bool isPuzzleSolved = false;
    private float diffX;
    private float diffY;

    void Start()
    {
        BlockRigidBody = MatchingBlock.GetComponent<Rigidbody>();
    }

    void Update()
    {
        diffX = Mathf.Abs(MatchingBlock.transform.position.x - gameObject.transform.position.x);
        diffY = Mathf.Abs(MatchingBlock.transform.position.y - gameObject.transform.position.y);

        CheckIfPuzzleSolved();
    }

    public bool GetPuzzleCondition()
    {
        return isPuzzleSolved;
    }

    private void CheckIfPuzzleSolved()
    {
        if (diffX < GameParameters.MinDiffForBlockPuzzle && diffY < GameParameters.MinDiffForBlockPuzzle)
        {
            MarkPuzzleAsSolved();
            gameObject.SetActive(false);
        }

    }

    private void MarkPuzzleAsSolved()
    {
        print("Solved");
        isPuzzleSolved = true;
        BlockRigidBody.mass = 99999f;
        Game.Instance.RoomCompleted();
    }
}
