using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss Instance;
    public Transform player;
    public Transform attackPoint;
    public bool isFlipped = false;
    public bool isInvulnerable = false;
    public Animator anim;

    public float currentBossHealth;
    public float deathTimeAnim = 0.6f;
    public HealthBar healthBar;

    private bool hasDied = false;
    private bool secondStage = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentBossHealth = GameParameters.BossMaxHealth;
        healthBar.SetMaxHealth(GameParameters.BossMaxHealth);

        DamageOnLoading();
    }

    private void Update()
    {
        if (IsDead() && !hasDied)
        {
            OnDeath();
            Game.Instance.RoomCompleted();
            hasDied = true;
        }

        if (currentBossHealth <= 200f)
        {
            secondStage = true;
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }

        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void OnHit()
    {
        if (isInvulnerable)
        {
            return;
        }

        if (Game.Instance.HasRoomBeenCleared(1))
        {
            TakeDamage(GameParameters.BulletUpgradedDmg);
        }

        else
        {
            TakeDamage(GameParameters.BulletBaseDmg);
        }

    }

    public bool IsSecondStage()
    {
        return secondStage;
    }

    private void DamageOnLoading()
    {
        int numRoomsComplete = Game.Instance.GetNumRoomsCompleted();

        TakeDamage(GameParameters.DmgToBossOnPuzzleCompletion * numRoomsComplete);
    }

    private bool IsDead()
    {
        if (currentBossHealth <= 0f)
        {
            return true;
        }

        return false;
    }

    private void TakeDamage(float dmgAmount)
    {
        currentBossHealth -= dmgAmount;
        healthBar.SetHealth(currentBossHealth);
    }

    public void OnDeath()
    {
        print("Boss dead");
        anim.SetTrigger("isDead");

        StartCoroutine(Destroytimer());
    }

    public void KillJohnLennon()
    {
        Destroy(gameObject);
    }

    public IEnumerator Destroytimer()
    {
        yield return new WaitForSeconds(deathTimeAnim);

        KillJohnLennon();
    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Boss_Death":
                    deathTimeAnim = clip.length;
                    break;
            }
        }
    }

}
