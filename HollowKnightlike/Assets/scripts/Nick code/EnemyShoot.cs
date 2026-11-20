using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShoot : MonoBehaviour
{
    [Header("Attack Hitbox")]
    public GameObject bullet;
    [Header("make this 0")]
    public float bulletSpeed = 2f;
    [Header("Time before attacking")]
    public float attackTime = 1f;
    public float windupTime = .1f;
    [Header("player")]
    GameObject player;
    float timer = 0;
    float windTimer = 0;
    public float shootTriggerDistance = 5;
    public Transform firePoint;
    private Rigidbody2D rb2d;
    [Header("Animator")]
    public Animator anim;
    bool isWinding = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        Vector3 playerDistance = player.transform.position - transform.position;

        if (playerDistance.magnitude < shootTriggerDistance)
        {
            //THE PLAYER IS CLOSE, GET 'EM
            anim.SetBool("Idle", false);
            windTimer += Time.deltaTime;

            if (windTimer > windupTime)
            {

                anim.SetBool("windingUp", true);
            }
            else
            {
                anim.SetBool("windingUp", false);
                
                anim.SetBool("Attacking", true);

                timer += Time.deltaTime;
                if (timer > attackTime)
                {
                    timer = 0;
                    GameObject shot = Instantiate(bullet, firePoint.position, Quaternion.identity);
                    playerDistance.Normalize();
                    shot.GetComponent<Rigidbody2D>().linearVelocity = playerDistance * bulletSpeed;
                    Destroy(shot, 1);
                }
            }
        }
        else
        {
            // Player is out of range: reset animations and timers
            anim.SetBool("Idle", true);
            anim.SetBool("windingUp", false);
            anim.SetBool("Attacking", false);
            windTimer = 0;
            timer = 0;
        }

    }     

    
}
