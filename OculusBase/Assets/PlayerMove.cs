using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public GameObject asteroid;
    Rigidbody rig;
    bool falling = true;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {      
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        if (falling)
            rig.velocity = transform.up * -1;
        transform.LookAt(asteroid.transform.position);
        transform.Rotate(Vector3.right * -90);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            falling = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            falling = false;
        }
    }
}
