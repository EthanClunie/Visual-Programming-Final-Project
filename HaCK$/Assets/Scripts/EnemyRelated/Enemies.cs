using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Enemy[] ListEnemies;

    public bool AllAreDead()
    {
        int cnt = 0;

        foreach (Enemy e in ListEnemies)
        {
            if (e == null)
            {
                ++cnt;
            }
        }

        return (cnt >= 7);
    }

}
