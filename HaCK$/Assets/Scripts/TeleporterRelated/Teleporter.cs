using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string sRoomToLoad;
    private bool canTeleport = true;
    private SpriteRenderer teleporterSpriteRenderer;

    private void Awake()
    {
        teleporterSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && canTeleport)
        {
            SceneHandler.Instance.LoadRoom(sRoomToLoad);
        }
    }

    public void LockPortal()
    {
        canTeleport = false;
        Color c = teleporterSpriteRenderer.color;
        c.a = 0;
        teleporterSpriteRenderer.color = c;
    }

    public void UnlockPortal()
    {
        canTeleport = true;
        if (teleporterSpriteRenderer != null)
        {
            Color c = teleporterSpriteRenderer.color;
            c.a = 1;
            teleporterSpriteRenderer.color = c;
        }

    }

}