using UnityEngine;

public class Spray : MonoBehaviour
{
    public ParticleSystem sprayParticleSystem;
    public bool isRight = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.parent.tag == "Player")
        {
            //if (transform.parent.transform.parent.tag == "Dinosaur")
            //    isRight = false;
            //else
            //    isRight = true;
            //OVRInput.Update();

            //// returns true if the primary button (typically “A”) is currently pressed.
            //if ((isRight && OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) ||
            //    (!isRight && OVRInput.Get(OVRInput.RawButton.LIndexTrigger)) ||
            //       (Input.GetMouseButton(0)))
            //{
            //    sprayParticleSystem.Play();
            //}
            //else
            //{
            //    sprayParticleSystem.Stop();
            //}
            sprayParticleSystem.Play();
        }
        if (transform.parent == null)
        {
            sprayParticleSystem.Stop();
        }
    }

    //private void FixedUpdate()
    //{
    //    OVRInput.FixedUpdate();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 3);
        }
    }
}
