using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    static int bulletCount;
    int myCount;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 30);
        myCount = bulletCount;
        bulletCount++;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletCount - myCount > 1000)
            Die();
    }
}
