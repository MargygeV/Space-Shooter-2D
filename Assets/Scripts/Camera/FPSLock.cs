using UnityEngine;

public class FPSLock : MonoBehaviour
{
    [SerializeField] private int fpsLimit;

    private void Awake()
    {
        Application.targetFrameRate = fpsLimit;
    }
}
