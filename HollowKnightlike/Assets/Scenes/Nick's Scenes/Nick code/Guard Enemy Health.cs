using UnityEngine;

public class GuardEnemyHealth : MonoBehaviour
{
    //Goal is to modify this into taking damage only during a specific timing, in this case while the attack animation plays

    public bool isInvulnerable { get; private set; } = true;
    //get the animation to change the previous code

    public Animator TEenemyAnim;

    public void Start()
    {
        health = 3;
    }
    public int health;
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent called at " + Time.time + " with a value of " + s);
    }

    public void AttackStart()
    {
        isInvulnerable = false;
    }
    public void AttackEnd()
    {
        isInvulnerable = true;
    }

    public void TakeDamage(int damage)
    {
        //if invulnerable, will play this code
        if (isInvulnerable)
        {
            //this did nothing
        }
        else
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


