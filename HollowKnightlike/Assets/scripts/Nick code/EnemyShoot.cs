using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
   
    public float bulletSpeed = 2f;
    public float attackTime = 3;
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

            Vector3 shootDir = player.transform.position - transform.position;
            if(shootDir.magnitude < shootTriggerDistance)
            {
                //THE PLAYER IS CLOSE, GET 'EM
            bool isWinding = true;
            anim.SetBool("windingUp", isWinding);
           
            timer += Time.deltaTime;
            if(timer > attackTime)
            {
                timer = 0;
                GameObject shot = Instantiate(bullet, firePoint.position, Quaternion.identity);
                shootDir.Normalize();
                shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * bulletSpeed;
                Destroy(shot, 1);
            } 
            }

            if (shootDir.magnitude > shootTriggerDistance)
            {

                bool isWinding = false;
                anim.SetBool("windingUp", isWinding);
            }

    }
}
