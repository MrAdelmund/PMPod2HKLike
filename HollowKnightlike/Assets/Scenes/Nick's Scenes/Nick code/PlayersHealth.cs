using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersHealth : MonoBehaviour
{
    private int playerHealth;

    public Image ImageHealth;
    public Sprite HealthFull;
    public Sprite Health2;
    public Sprite Health1;
    public Sprite Health0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerHealth--;
        }

        if (playerHealth == 3)
        {
            ImageHealth.sprite = HealthFull;
        }
        if (playerHealth == 2)
        {
            ImageHealth.sprite = Health2;
        }
        if (playerHealth == 1)
        {
            ImageHealth.sprite = Health1;
        }
        if (playerHealth == 0)
        {
            ImageHealth.sprite = Health0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
