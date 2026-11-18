using UnityEngine;
using UnityEngine.SceneManagement;

public class Horrormode : MonoBehaviour
{
    //Jop application time :3
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(7);
    }
}
