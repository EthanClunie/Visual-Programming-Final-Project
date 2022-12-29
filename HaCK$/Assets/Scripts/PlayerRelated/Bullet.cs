using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance;
    public Rigidbody BulletRigidBody;
    public Animator animator;

    void Start()
    {
        Instance = this;

        BulletRigidBody.velocity = transform.right * GameParameters.BulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Boss.Instance.OnHit();

            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            // Rest in Enemy class
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
