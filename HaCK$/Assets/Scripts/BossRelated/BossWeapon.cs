using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public float attackDamage = GameParameters.BossBaseAttackDamage;
	public float enragedAttackDamage = GameParameters.BossEnragedAttackDamage;
	public Boss boss;

	public Vector3 attackOffset;
	public float attackRange = GameParameters.BossAttackRange;
	public LayerMask enemyLayers;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider[] hitPlayers = Physics.OverlapSphere(boss.attackPoint.position, attackRange, enemyLayers);
		if (hitPlayers.Length == 0)
		{
			// Nothing has been hit
		}
		else
		{
			foreach (Collider player in hitPlayers)
			{
				print("Hit (Normal).");
				if (player.gameObject.tag == "Player")
				{
					print("Player hit");
					Player.Instance.OnHit();
				}

			}
		}

	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider[] hitPlayers = Physics.OverlapSphere(pos, attackRange, enemyLayers);
		if (hitPlayers.Length == 0)
		{
			// Nothing has been hit
		}
		else
		{
			foreach (Collider player in hitPlayers)
			{
				print("Hit (Enraged).");
				if (player.gameObject.tag == "Player")
				{
					print("Player hit");
					Player.Instance.OnHit();
				}

			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}