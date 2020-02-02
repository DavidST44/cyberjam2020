using UnityEngine;
using UnityEngine.SceneManagement;

public class Crystal : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.GetInt("Crystal");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CrystalDeath();
        }
    }

    public void CrystalDeath()
    {
        PlayerPrefs.SetInt("Crystal", PlayerPrefs.GetInt("Crystal") + 1);
        if (PlayerPrefs.GetInt("Crystal") >= 1)
        {
            PlayerPrefs.SetInt("Crystal", 0);
            //SceneManager.LoadScene("");            
        }
        Destroy(gameObject);
    }
}
