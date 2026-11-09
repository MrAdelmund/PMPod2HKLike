using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void OnCollider2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("level1Win"))
        {
            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.CompareTag("level2Win"))
        {
            SceneManager.LoadScene(5);
        }
        if (collision.gameObject.CompareTag("level3Win"))
        {
            SceneManager.LoadScene(6);
        }
    }
}
