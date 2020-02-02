using UnityEngine;

public class Crystal : MonoBehaviour
{
    OriginalStartUpCheck countMe;
    private void Start()
    {
        countMe = GameObject.Find("CC").GetComponent<OriginalStartUpCheck>();
    }

    public void CrystalDeath()
    {
        if(countMe != null)
        {
            countMe.current++;
        }
        Destroy(gameObject);
    }
}
