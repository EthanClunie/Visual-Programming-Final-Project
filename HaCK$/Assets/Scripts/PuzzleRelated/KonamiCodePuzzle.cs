using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(KonamiCode))]
public class KonamiCodePuzzle : MonoBehaviour
{
    private KonamiCode KonamiCode;
    private bool isSolved = false;

    void Start()
    {
        KonamiCode = gameObject.GetComponent<KonamiCode>();
    }

    void Update()
    {
        if (KonamiCode.success && !isSolved)
        {
            print("Nice code");
            Game.Instance.RoomCompleted();
            isSolved = true;
        }
    }
}
