using UnityEngine;

public class SpinnerDmg : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("Bullet destroyed");
            Destroy(gameObject);
        }
    }
}
