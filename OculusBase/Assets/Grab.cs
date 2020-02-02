using UnityEngine;
using UnityEngine.SceneManagement;

public class Grab : MonoBehaviour
{
    GameObject selected, pick, crystal;
    Rigidbody pickRig;
    AudioSource playerSource;
    public bool isRight;
    public GameObject hand;
    public GameObject hinge;
    bool secondHand;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            Click();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
        {
            UnClick();
        }

        if (secondHand)
        {
            //Portal transforms to match hand
            Vector3 lerp = Vector3.Lerp(transform.position, hand.transform.position, 0.5f);
            selected.transform.position = lerp;
            selected.transform.LookAt(hand.transform.position);
            selected.transform.Rotate(Vector3.forward * 90);
            float handSpread = Vector3.Distance(transform.position, hand.transform.position);
            selected.transform.localScale = new Vector3(handSpread, selected.transform.localScale.y, handSpread);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            selected = other.gameObject;
        }
        if (other.tag == "Interactable")
        {
            other.GetComponent<AudioSource>().Play();
        }
        if (other.tag == "PickUp")
        {
            pick = other.gameObject;
        }
        if (other.tag == "Crystal")
        {
            crystal = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            selected = null;
        }
        if (other.tag == "PickUp")
        {
            pick = null;
        }
        if (other.tag == "Crystal")
        {
            crystal = null;
        }
    }

    void Click()
    {
        if (crystal != null)
        {
            crystal.GetComponent<Crystal>().CrystalDeath();
            crystal = null;
        }
        if (selected != null)
        {            
            if(selected.transform.parent == hand.transform)
            {
                secondHand = true;
            }
            else
                selected.transform.parent = gameObject.transform;
        }
        if(pick != null)
        {
            pick.transform.parent = gameObject.transform;
            pickRig = pick.GetComponent<Rigidbody>();
            pickRig.useGravity = false;
            pickRig.isKinematic = true;
        }
    } 

    void UnClick()
    {
        secondHand = false;
        if (selected != null)// && (selected.transform.parent == gameObject.transform || selected.transform.parent == hand.transform))
        {
            selected.transform.parent = null;
        }
        if(pick != null)
        {
            pick.transform.parent = null;
            pickRig.useGravity = true;
            pickRig.isKinematic = false;
            pickRig = null;
        }
    }
}
