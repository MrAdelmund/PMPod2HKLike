using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(4);
    }
}
