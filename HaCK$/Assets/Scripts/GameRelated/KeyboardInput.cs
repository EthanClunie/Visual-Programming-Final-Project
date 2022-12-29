using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public PlayerController2D PlayerController;
    public PlayerWeapon PlayerWeapon;
    public Animator animator;

    private bool isSprinting = false;

    void Update()
    {
        if (Game.Instance.IsGamePaused())
        {
            // Game Management
            if (Input.GetKeyDown(KeyCode.P))
            {
                Game.Instance.ResumeGame();
            }
        }
        else
        {
            // Game Management
            if (Input.GetKeyDown(KeyCode.P))
            {
                Game.Instance.PauseGame();
            }

            // Movement
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
                PlayerMove(isSprinting);
                isSprinting = false;
            }
            else
            {
                PlayerMove(isSprinting);
            }


        }

        // Game Exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.Instance.QuitGame();
        }

    }

    private void PlayerMove(bool isDashing)
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerController.MoveManually(new Vector2(0, 1), isDashing);
            animator.SetTrigger("Player_Walk");
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerController.MoveManually(new Vector2(-1, 0), isDashing);
            PlayerWeapon.CorrectAimDirection(new Vector2(-1, 0));
            animator.SetTrigger("Player_Walk");
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerController.MoveManually(new Vector2(0, -1), isDashing);
            animator.SetTrigger("Player_Walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerController.MoveManually(new Vector2(1, 0), isDashing);
            PlayerWeapon.CorrectAimDirection(new Vector2(1, 0));
            animator.SetTrigger("Player_Walk");
        }
    }

}
