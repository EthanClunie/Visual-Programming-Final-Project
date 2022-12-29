using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Animator animator;
    public GameObject BulletFirePoint;

    public HealthBar healthBar;

    private GameObject[] players;

    public float currentPlayerHealth;
    private bool isTakingDamage;

    void Awake()
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
        DontDestroyOnLoad(gameObject);

        currentPlayerHealth = GameParameters.PlayerMaxHealth;
        healthBar.SetMaxHealth(GameParameters.PlayerMaxHealth);
        isTakingDamage = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }

    public bool IsPlayerDead()
    {
        return (currentPlayerHealth <= 0);
    }

    public void PlayerDeath()
    {
        // Play animation for death
        Destroy(Instance.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();

        DestroyExtraPlayers();
    }

    private void DestroyExtraPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            Destroy(players[1]);
        }
    }

    private void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }

    public void OnHit()
    {
        if (Boss.Instance.IsSecondStage())
        {
            TakeDamage(GameParameters.BossEnragedAttackDamage);
        }
        else
        {
            TakeDamage(GameParameters.BossBaseAttackDamage);
        }

    }

    private void TakeDamage(float dmgAmount)
    {
        currentPlayerHealth -= dmgAmount;

        if (isTakingDamage)
        {
            StopCoroutine(DamageAnimation());
            StartCoroutine(DamageAnimation());
        }
        else
        {
            StartCoroutine(DamageAnimation());
        }

        healthBar.SetHealth(currentPlayerHealth);
    }

    IEnumerator DamageAnimation()
    {
        isTakingDamage = true;
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}