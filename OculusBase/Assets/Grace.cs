using UnityEngine;

public class Grace : MonoBehaviour
{
    public SoundRandomizer[] soundRando;
    public int graceRounds;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GraceOver", graceRounds);
    }

    void GraceOver()
    {
        foreach (SoundRandomizer sound in soundRando)
        {
            sound.enabled = true;
        }
    }
}
