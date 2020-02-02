using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginalStartUpCheck : MonoBehaviour
{
    public int win, current;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if(current == win)
        {
            SceneManager.LoadScene("IslandOfWin");
        }
    }
}
