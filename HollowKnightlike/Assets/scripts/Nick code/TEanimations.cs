using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(GuardEnemyHealth))]
public class TEanimations : MonoBehaviour
{
    //make it so the tank enemy attacks if the player is close
    [Header("Attack Settings")]
    public int attackDamage = 1;
    public float attackRange = 1.5f;
    public float attackCooldown = 5f;
    public Transform target;
    Vector3 enemyPosition;


    [Header("Attack Detection")]
    public Transform attackPoint;
    public LayerMask playerLayers;
    private Vector3 playerDistance;
    Rigidbody2D rb;


    [Header("References")]
    public PlayerMovement playerMovement;
    public bool isAttacking = false;
    float cooldownTimer = 0;
    Seeker seeker;
    public Transform currentTarget;
    public Transform home;
    public GameObject player;

    [Header("Animator")]
    public Animator TEenemyAnim;

    void Start()
    {
        //Grab the bool from the attack vulnerability and make them be able to be attacked, make sure the attack timing is availiable
        //for 5 seconds
        GetComponent<GuardEnemyHealth>().isInvulnerable = true;

        //this grabs the animator from the current object that this has been put on
        TEenemyAnim = GetComponent<Animator>();

        //I am unsure of what seeker does, It's from A* pathfinding, and I wish these had comments explaining it better 
        //than the hover comments
        seeker = GetComponent<Seeker>();

        //does NOT move, so no rigidbody's needed
        //
        currentTarget = home;

        //set the target to the player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        //you need to calculate the distance to the player
        //we did that before, look at some of the previous code. Enemy chase, shoot, etc
        //this variable, playerDistance, isn't actually changing in the code at all to recalculate how far it is to the player
        playerDistance = player.transform.position - transform.position;

        //ok if im correct the animator should be able to implement this, MY BRAIN PUT 2 AND 2 TOGETHER AND I GOT FISH
        if (isAttacking)
        {
            TEenemyAnim.SetBool("attacking", true);
        }
        else
        {
            TEenemyAnim.SetBool("attacking", false);
        }

        if (playerDistance.magnitude < attackRange)
        {
            Attack();
            isAttacking = true;
            GetComponent<GuardEnemyHealth>().isInvulnerable = false;
            //play attack animation... ill ask
           


        }

        if (cooldownTimer <= 5)
        {
            isAttacking = false;
            GetComponent<GuardEnemyHealth>().isInvulnerable = true;
            //play recovery from attack anim into idle anim
            cooldownTimer = 0;
        }
    }

    void Attack()
    {
        cooldownTimer = attackCooldown;

        // Determine attack direction based on facing
        Vector2 attackDirection = Vector2.right * player.transform.position; //make this player position

        // Calculate attack position
        Vector2 attackPosition = (Vector2)attackPoint.position + attackDirection * attackRange * 0.5f;
        //play attack animation
        if (attackPoint.GetComponent<Animator>() != null)
        {
            attackPoint.GetComponent<Animator>().SetTrigger("Attack");
        }
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(
            attackPosition,
            attackRange,
            playerLayers
        );

        foreach (Collider2D Player in playerHit)
        {
            Player.SendMessage("TakeDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        if (playerMovement == null) return;

        Vector2 attackDirection = Vector2.right * playerMovement.facingDirection; //instead of facing direction, make this player position.
        Vector2 attackPosition = (Vector2)attackPoint.position + attackDirection * attackRange * 0.5f;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }
}
