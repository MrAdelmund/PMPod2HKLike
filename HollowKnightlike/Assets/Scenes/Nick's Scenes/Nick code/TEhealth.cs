using UnityEngine;

public class TEhealth : MonoBehaviour
{
    public int health = 3;


    private int immortalFrames; //Tie this in when the enemy animations are done and ready
    public void TakeDamage(int damage)
    {
        if (immortalFrames <= 0)
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
