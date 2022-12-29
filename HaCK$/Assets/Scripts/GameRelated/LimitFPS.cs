using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = GameParameters.TargetFrameRate;
    }
    
}
