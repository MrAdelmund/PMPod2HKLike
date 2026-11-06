using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersHealth : MonoBehaviour
{
    private int playerHealth;

    public Image ImageHealth1;
    public Image ImageHealth2;
    public Image ImageHealth3;


    public Sprite HealthFull;
    public Sprite Health2;
    public Sprite Health1;
    public Sprite Health0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = 9;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerHealth--;
        }
        if (playerHealth == 9)
        {
            ImageHealth3.sprite = HealthFull;
        }
        if (playerHealth == 8)
        {
            ImageHealth3.sprite = Health2;
        }
        if (playerHealth == 7)
        {
            ImageHealth3.sprite = Health1;
        }
        if (playerHealth == 6)
        {
            ImageHealth2.sprite = HealthFull;
            ImageHealth3.sprite = Health0;
        }
        if (playerHealth == 5)
        {
            ImageHealth2.sprite = Health2;
        }
        if (playerHealth == 4)
        {
            ImageHealth2.sprite = Health1;
        }
        if (playerHealth == 3)
        {
            ImageHealth1.sprite = HealthFull;
            ImageHealth2.sprite = Health0;

        }
        if (playerHealth == 2)
        {
            ImageHealth1.sprite = Health2;
        }
        if (playerHealth == 1)
        {
            ImageHealth1.sprite = Health1;
        }
        if (playerHealth == 0)
        {
            ImageHealth1.sprite = Health0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
