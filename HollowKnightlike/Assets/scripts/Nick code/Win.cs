using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Won();
    }

    private void Won()
    {
        SceneManager.LoadScene(2);
    }
}
