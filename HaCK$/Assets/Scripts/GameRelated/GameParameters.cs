using System.Collections;
using System.Collections.Generic;

public static class GameParameters
{
    // Game
    public static int TargetFrameRate = 60;

    // Game Completion
    public static float SecondsTillGameWinDisplay = 0.75f;
    public static float SecondsTillGameOverDisplay = 0.75f;

    // Camera
    public static float ScreenShakeDuration = 1.0f;
    public static float ScreenShakeMagnitude = 0.3f;

    // Scenes
    public static string GameOverSceneName = "GameOverScreen";
    public static string HubRoomSceneName = "MainHub";

    // Player
    public static float PlayerMaxHealth = 100;
    public static float PlayerMoveAmount = 0.085f;
    public static float SprintMoveIncrease = 0.0425f;

    // Boss
    public static float BossMaxHealth = 500;

    public static float BossBaseMoveSpeed = 2.5f;
    public static float BossEnragedMoveSpeed = 4f;

    public static float BossAttackRange = 1.5f;
    public static float BossBaseAttackDamage = 20;
    public static float BossEnragedAttackDamage = 35;

    // Enemy
    public static float EnemyMaxHealth = 50f;

    // Bullet
    public static float BulletSpeed = 20f;
    public static float BulletBaseDmg = 10;
    public static float BulletUpgradedDmg = 20;

    // Puzzles
    public static float DmgToBossOnPuzzleCompletion = 25;

    public static float MinDiffForBlockPuzzle = 0.1f;

    public static float WaitTimeForNextKeyKonamiCode = 0.5f;
    public static float TimeDisplayKonamiSuccess = 5f;
}
