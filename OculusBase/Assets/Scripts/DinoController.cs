using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoController : MonoBehaviour {
    public bool isMoving = false;
    private Animator animator;
    private AudioSource roar;
    GameObject[] targets;
    private NavMeshAgent agent;

    public float hp = 1000;
    float maxHp;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        roar = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;

        targets = GameObject.FindGameObjectsWithTag("Marker");
        maxHp = hp;
        Invoke("GoPlaces", 0.5f);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 30;
            float size = hp / maxHp;
            size /= 2;
            Debug.Log("Size" + size);
            size += 0.5f;
            Debug.Log("Scaling to " + size);
            if (size >= 0.5f && size <= 1.0f)
            {
                transform.localScale = new Vector3(size, size, size);
            }
        }
        if (hp <= 0)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isRoaring", true); // Triggered!
            roar.Play();

            animator.SetBool("isMoving", true);
            int dest = Random.Range(0, targets.Length);
            agent.SetDestination(targets[dest].transform.position);
        }
        else if (!agent.hasPath && agent.remainingDistance < 0.1f)// agent.velocity.sqrMagnitude < 0.1f)
        {
            animator.SetBool("isMoving", false);
        }
       
    }

    void GoPlaces()
    {
        if (Random.Range(0, 100) > 70)
        {
            animator.SetBool("isRoaring", true); // Triggered!
            roar.Play();
        }
        else
        {
            animator.SetBool("isMoving", true);
            int dest = Random.Range(0, targets.Length);
            agent.SetDestination(targets[dest].transform.position);
        }
        Invoke("GoPlaces", Random.Range(3.0f, 10.0f));
    }
}
