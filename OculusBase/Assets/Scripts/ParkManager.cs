using UnityEngine;
using System.Collections;

public class ParkManager : MonoBehaviour
{
    public GameObject[] dinos;
    public GameObject[] targets;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ParkMonitor", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ParkMonitor()
    {
        int dinoCount = GameObject.FindGameObjectsWithTag("Dinosaur").Length;

        if (dinoCount < 4)
        {
            for (int i = 0; i < 5; i++)
            {
                int pos = Random.Range(0, targets.Length);
                int dino = Random.Range(0, dinos.Length);
                Instantiate<GameObject>(dinos[dino], targets[pos].gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
