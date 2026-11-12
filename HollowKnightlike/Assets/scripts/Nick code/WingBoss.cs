using UnityEngine;
using UnityEngine.SceneManagement;

public class WingBoss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Won();
    }

    private void Won()
    {
        SceneManager.LoadScene(5);
    }
}
