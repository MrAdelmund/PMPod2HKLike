using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Spinner")
        {
            Debug.Log("Enemy was shot!");
            health -= 2;
            if (health <= 0)
            {
                Debug.Log("Enemy Down!");
                Destroy(gameObject);
            }

        }

    }
}
