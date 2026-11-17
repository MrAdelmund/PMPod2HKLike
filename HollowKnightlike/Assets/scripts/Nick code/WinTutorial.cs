using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTutorial : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Won();
        }
    }

    private void Won()
    {
        SceneManager.LoadScene(2);
    }
}
