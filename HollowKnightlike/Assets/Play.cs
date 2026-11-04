using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void LoadLevel(string basicArea)
    {
        SceneManager.LoadScene(basicArea);
        
    }
}
