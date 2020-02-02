using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public string level;
    OriginalStartUpCheck cc;

    void Start()
    {
        cc = GameObject.Find("CC").GetComponent<OriginalStartUpCheck>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && transform.localScale.x >= 0.4f)
        {
            if(cc.won)
            {
                SceneManager.LoadScene("IslandOfWin");
            }
            else
                SceneManager.LoadScene(level);
        }
    }
}
