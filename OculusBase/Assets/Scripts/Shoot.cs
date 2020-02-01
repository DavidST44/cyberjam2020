using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
     //  InvokeRepeating("Shoott", 5, 5);
    }

    void Shoott()
    {
        GameObject newB = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newB.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000);
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        // returns true if the primary button (typically “A”) is currently pressed.
        if ((isRight && OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) ||
            (!isRight && OVRInput.Get(OVRInput.RawButton.LIndexTrigger)) ||
               (Input.GetMouseButton(0)))
        {
            InvokeRepeating("Pulse", 1.0f / 5, 1.0f / 5);
        }
        else
        {
            CancelInvoke();
        }
    }

    void Pulse()
    {
        GameObject newB = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newB.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1500);
    }
}
