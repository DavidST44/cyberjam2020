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
        else
            sprayParticleSystem.Stop();
    }

    //private void FixedUpdate()
    //{
    //    OVRInput.FixedUpdate();
    //}
}
