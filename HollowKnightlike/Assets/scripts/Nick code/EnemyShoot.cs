using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
   
    public float bulletSpeed = 2f;
    public float shootDelay = 3;
    public float windupTime = 3;
    GameObject player;
    float timer = 0;
    float windTimer = 0;
    public float shootTriggerDistance = 5;
    public Transform firePoint;
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

        timer += Time.deltaTime;
        if(timer > shootDelay)
        {
            timer = 0;

            Vector3 shootDir = player.transform.position - transform.position;
            if(shootDir.magnitude < shootTriggerDistance)
            {
                //THE PLAYER IS CLOSE, GET 'EM
                bool isWinding = true;
                anim.SetBool("windingUp", isWinding);
                windTimer += Time.deltaTime;
                if(windTimer > windupTime)
                {
                    bool isAttacking = true;
                    GameObject shot = Instantiate(bullet, firePoint.position, Quaternion.identity);
                    shootDir.Normalize();
                    shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * bulletSpeed;
                    anim.SetBool("isSmashing", isAttacking);
                    Destroy(shot, 3);
                }

            }
        }
    }
}
