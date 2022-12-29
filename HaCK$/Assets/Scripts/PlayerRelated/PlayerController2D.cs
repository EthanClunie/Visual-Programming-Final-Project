using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public static PlayerController2D Instance;
    private SpriteRenderer playerSpriteRenderer;

    private bool canSprint;

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

        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        canSprint = false;
    }

    public void MoveManually(Vector2 direction, bool isSprinting)
    {
        Move(direction, isSprinting);
    }

    public void UnlockSprint()
    {
        canSprint = true;
    }

    private void Move(Vector2 direction, bool isSprinting)
    {
        FaceCorrectDirection(direction);
        playerSpriteRenderer.transform.Translate(CalculateAmountToMove(direction, isSprinting));
        KeepOnScreen();
    }

    private Vector3 CalculateAmountToMove(Vector2 direction, bool isSprinting)
    {
        float amountX;
        float amountY;
        if (isSprinting && canSprint)
        {
            amountX = direction.x * (GameParameters.PlayerMoveAmount + GameParameters.SprintMoveIncrease);
            amountY = direction.y * (GameParameters.PlayerMoveAmount + GameParameters.SprintMoveIncrease);
        }
        else
        {
            amountX = direction.x * (GameParameters.PlayerMoveAmount);
            amountY = direction.y * (GameParameters.PlayerMoveAmount);
        }

        return new Vector3(amountX, amountY, 0);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {

        if (direction.x == 1) // face right
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (direction.x == -1) // face left
        {
            playerSpriteRenderer.flipX = true;
        }
    }

    private void KeepOnScreen()
    {
        playerSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(playerSpriteRenderer);
    }
}
