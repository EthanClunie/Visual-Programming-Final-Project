using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon Instance;
    public Transform FirePoint;
    public GameObject BulletFirePoint;
    public GameObject BulletPrefab;

    private SpriteRenderer BulletSpriteRenderer;

    private bool isShootingUnlocked;

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

        BulletSpriteRenderer = BulletFirePoint.GetComponent<SpriteRenderer>();
        isShootingUnlocked = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (BulletSpriteRenderer.flipX)
            {
                TryToShoot(new Vector2(-1, 0));
            }
            else
            {
                TryToShoot(new Vector2(1, 0));
            }
        }

    }

    public void CorrectAimDirection(Vector2 direction)
    {
        CorrectFirePosition(direction);
    }

    public void TryToShoot(Vector2 direction)
    {
        if (isShootingUnlocked)
        {
            Shoot(direction);
        }
        else
        {
            print("Cannot shoot here.");
        }    
    }

    public void ToggleShooting()
    {
        isShootingUnlocked = !isShootingUnlocked;
    }

    private void Shoot(Vector2 direction)
    {
        if (direction.x == 1)
        {
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        }
        else if (direction.x == -1)
        {
            FirePoint.transform.Rotate(0f, 180f, 0f);
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.transform.rotation);
            FirePoint.transform.Rotate(0f, 180f, 0f);
        }
        
    }

    private void CorrectFirePosition(Vector2 direction)
    {
        if (direction.x == 1) // face right
        {
            FirePoint.position = GameObject.FindWithTag("FirePointRightPos").transform.position;
            BulletSpriteRenderer.flipX = false;
        }
        else if (direction.x == -1) // face left
        {
            BulletSpriteRenderer.gameObject.transform.position = GameObject.FindWithTag("FirePointLeftPos").transform.position;
            BulletSpriteRenderer.flipX = true;
        }
    }

}
