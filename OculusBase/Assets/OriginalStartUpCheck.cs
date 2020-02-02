using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginalStartUpCheck : MonoBehaviour
{
    public int win, current;
    public bool won = false;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if(current == win)
        {
            SceneManager.LoadScene("IslandOfWin");
        }
    }
    
    public void checkWin()
    {
        if (current == win)
        {
            won = true;
            //SceneManager.LoadScene("IslandOfWin");
        }
    }
}
