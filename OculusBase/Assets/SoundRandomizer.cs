using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] audioclips;
    public AudioSource audioSource;
    bool waitForEnd;
    void Start()
    {
        RandomSoundSet();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.isPlaying)
        {
            waitForEnd = true;
        }
        if(waitForEnd && !audioSource.isPlaying)
        {
            RandomSoundSet();
        }
    }

    void RandomSoundSet()
    {
        audioSource.clip = audioclips[Random.Range(0, audioclips.Length)];
    }
}
