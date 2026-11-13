using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(GuardEnemyHealth))]
public class TEattack : MonoBehaviour
{
    //make it so the tank enemy attacks if the player is close
    [Header("Attack Settings")]
    public int attackDamage = 1;
    public float attackRange = 1.5f;
    public float attackCooldown = 5f;
    private float playerDistance;


    [Header("Attack Detection")]
    public Transform attackPoint;
    public LayerMask playerLayers;

    [Header("Referances")]
    public PlayerMovement playerMovement;
    public bool isAttacking = false;
    float cooldownTimer;
    public Animator TEenemyAnim;

    void Start()
    {
        GetComponent<GuardEnemyHealth>().isInvulnerable = true;
        TEenemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (playerDistance <= attackRange)
        {
            Attack();
            isAttacking = true;
            GetComponent<GuardEnemyHealth>().isInvulnerable = false;
        }

        if (cooldownTimer <= 0)
        {
            isAttacking = false;
            GetComponent<GuardEnemyHealth>().isInvulnerable = true;
        }
    }

    void Attack()
    {
        cooldownTimer = attackCooldown;

        // Determine attack direction based on facing
        Vector2 attackDirection = Vector2.right * playerMovement.facingDirection; //make this player position

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
        /*if (attackPoint == null) return;

        if (playerMovement == null) return;*/

        Vector2 attackDirection = Vector2.right * playerMovement.facingDirection; //instead of facing direction, make this player position.
        Vector2 attackPosition = (Vector2)attackPoint.position + attackDirection * attackRange * 0.5f;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }
}
