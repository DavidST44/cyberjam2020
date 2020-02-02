using UnityEngine;

public class OriginalStartUpCheck : MonoBehaviour
{
    public bool firstStart = true;

    void Start()
    {
        if (firstStart)
            PlayerPrefs.SetInt("Crystal", 0);
    }
}
