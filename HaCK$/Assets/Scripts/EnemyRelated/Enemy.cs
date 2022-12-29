using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    private bool hasDied = false;

    void Start()
    {
        health = GameParameters.EnemyMaxHealth;
    }

    private void Update()
    {
        if (IsDead() && !hasDied)
        {
            hasDied = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            OnHit();
            Destroy(other.gameObject);
        }
    }

    public void OnHit()
    {
        if (Game.Instance.HasRoomBeenCleared(1))
        {
            TakeDamage(GameParameters.BulletUpgradedDmg);
        }
        else
        {
            TakeDamage(GameParameters.BulletBaseDmg);
        }
    }

    private void OnDestroy()
    {
        // Play some destruction animation or something
    }

    private bool IsDead()
    {
        if (health <= 0f)
        {
            return true;
        }

        return false;
    }

    private void TakeDamage(float dmgAmt)
    {
        health -= dmgAmt;
    }
}
