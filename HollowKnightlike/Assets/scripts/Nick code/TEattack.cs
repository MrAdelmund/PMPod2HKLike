using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(GuardEnemyHealth))]
public class TEattack : MonoBehaviour
{
    //make it so the tank enemy attacks if the player is close
    [Header("Attack Settings")]
    public int attackDamage = 1;
    public float attackRange = 0.5f;
    public float attackCooldown = 1f;
    public float playerDistance = 2f;
    public float attackSpeed = 1f;

    public float attackTime = 0;


    [Header("Attack Detection")]
    public GameObject player;
    public LayerMask playerLayers;

    [Header("Referances")]
    public PlayerMovement playerMovement;
    public bool isAttacking = false;
    float cooldownTimer;
    public GameObject hit;

    void Start()
    {
        GetComponent<GuardEnemyHealth>().isInvulnerable = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (attackTime > attackCooldown)
        {
            attackTime = 0;
            //shooot is off cooldown, try to shoot at the player
            Vector3 AttDir = player.transform.position - transform.position;
            if (AttDir.magnitude < playerDistance)
            {
                //THE PLAYER IS CLOSE, GET 'EM

                isAttacking = true;
                GetComponent<GuardEnemyHealth>().isInvulnerable = false;
                GameObject shot = Instantiate(hit, transform.position, Quaternion.identity);
                AttDir.Normalize();
                shot.GetComponent<Rigidbody2D>().linearVelocity = AttDir * attackSpeed;
                Destroy(shot, 10);
            }
        }
    }
}
       
  
