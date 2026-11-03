using UnityEngine;

public class GuardEnemyHealth : MonoBehaviour
{
    //Goal is to modify this into taking damage only during a specific timing, in this case while the attack animation plays

    public void Start()
    {
        
    }
    public int health = 3;
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent called at " + Time.time + " with a value of " + s);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
