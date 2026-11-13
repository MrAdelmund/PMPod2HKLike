using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{

    public Image ImageHealth;
    public Sprite Health0;

    public int health = 3;
    public float ydeath = -40f;
    public Vector2 customCoordinates = new Vector2(-15f, -4f);

    private void Update()
    {
        if (transform.position.y < ydeath)
        {
            health = 0;
            Debug.Log("Player has fallen");
            {
                if (health <= 0)
                {
                    Scene currentScene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(currentScene.name);
                    transform.position = customCoordinates;
                    Debug.Log("Player has died");
                    ImageHealth.sprite = Health0;
                }
            }
        }

    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit an enemy!");
            health -= 1;

            if (health <= 0)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
                transform.position = customCoordinates;
                Debug.Log("Player has died");
            }
        }
    }
}
