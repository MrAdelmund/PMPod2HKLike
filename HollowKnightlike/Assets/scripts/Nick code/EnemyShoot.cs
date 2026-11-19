using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;

    [Header("Attack Timing")]
    public float bulletSpeed = 2f;
    public float attackTime = 3;
    public float windupTime = 3;
    float timer = 0;
    float windTimer = 0;
    public float shootTriggerDistance = 5;
    bool isWinding = false;

    [Header("Player")]
    GameObject player;
    public Transform firePoint;

    [Header("Rigidbody & Animator")]
    private Rigidbody2D rb2d;
    public Animator anim;

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
            bool isWinding = true;
            anim.SetBool("windingUp", isWinding);
            bool isIdle = false;
            anim.SetBool("Idle", isIdle);

            timer += Time.deltaTime;
        }
        else if (playerDistance.magnitude > shootTriggerDistance)
        {

            bool isWinding = false;
            anim.SetBool("windingUp", isWinding);
            bool isIdle = true;
            anim.SetBool("Idle", isIdle);
        }

        if (timer > attackTime)
        {
             timer = 0;

             bool isAttacking = true;
             anim.SetBool("Attacking", isAttacking);

             GameObject shot = Instantiate(bullet, firePoint.position, Quaternion.identity);
             playerDistance.Normalize();
             shot.GetComponent<Rigidbody2D>().linearVelocity = playerDistance * bulletSpeed;
             Destroy(shot, 1);
        }
    

            
        

    }
}
