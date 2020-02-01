using UnityEngine;
using UnityEngine.SceneManagement;

public class Grab : MonoBehaviour
{
    GameObject selected;
    AudioSource playerSource;
    public bool isRight;
    public GameObject hand;
    int scene;
    bool secondHand;
    float xDis, zDis;
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
        //if (other.tag == "Interactable")
        //{
        //    Debug.Log("interacterable");
        //    selected = other.gameObject;
        //    selected.GetComponent<MeshRenderer>().enabled = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Interactable")
        //{
        //    selected.GetComponent<MeshRenderer>().enabled = false;
        //    selected = null;
        //}
        if (other.tag == "Portal")
        {
            selected = null;
        }
    }

    void Click()
    {
        if (selected != null)
        {            
            if(selected.transform.parent == hand.transform)
            {
                secondHand = true;
            }
            else
                selected.transform.parent = gameObject.transform;
        }
    } 

    void UnClick()
    {
        secondHand = false;
        if (selected != null)// && (selected.transform.parent == gameObject.transform || selected.transform.parent == hand.transform))
        {
            selected.transform.parent = null;
        }
    }
}
