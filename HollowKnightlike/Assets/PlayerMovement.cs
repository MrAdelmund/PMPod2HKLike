using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 16f;

    [Header("Dash")]
    public bool dashEnabled = true;
    public float dashSpeed = 20f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.5f;

    [Header("Double Jump")]
    public bool doubleJumpEnabled = true;

    [Header("Wall Jump")]
    public bool wallJumpEnabled = true;
    public float wallJumpForceX = 12f;
    public float wallJumpForceY = 16f;
    public float wallSlidingSpeed;
    public bool isTouchingWall;
    public bool isWallSliding = false;
    public bool canDoubleJump;
    public bool isDashing;


    [Header("Coyote Time")]
    public bool coyoteTimeEnabled = true;
    public float coyoteTime = 0.15f;
 
    [Header("Ground Check")]
    [SerializeField] public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    [SerializeField] public LayerMask groundLayer;
    public bool isGrounded;

    [Header("Wall Check")]
    [SerializeField] public Transform wallCheckLeft;
    [SerializeField] public Transform wallCheckRight;
    [SerializeField] public LayerMask wallLayer;
    public float wallCheckDistance = 0.3f;

    bool touchingWallLeft;
    bool touchingWallRight;

    [SerializeField] Rigidbody2D rb;

    public float moveInput;

    float coyoteTimer;
    float dashTimer;
    float dashCooldownTimer;

    public int facingDirection = 1;

    public Animator anim;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) return;

        moveInput = Input.GetAxis("Horizontal");

        CheckGround();
        CheckWall();

        HandleMovement();
        HandleJump();
        HandleDash();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            canDoubleJump = true;

            if (coyoteTimeEnabled)
                coyoteTimer = coyoteTime;
        }
        else
        {
            if (coyoteTimeEnabled)
                coyoteTimer -= Time.deltaTime;
        }
    }

    void CheckWall()
    {
        Vector3 leftOrigin = wallCheckLeft.position;
        Vector3 rightOrigin = wallCheckRight.position;

        if (transform.localScale.x < 0)
        {
            leftOrigin = wallCheckRight.position;
            rightOrigin = wallCheckLeft.position;
        }

        touchingWallLeft = Physics2D.Raycast(leftOrigin, Vector2.left, wallCheckDistance, groundLayer);
        touchingWallRight = Physics2D.Raycast(rightOrigin, Vector2.right, wallCheckDistance, groundLayer);
        bool isTouchingWall = touchingWallRight || touchingWallLeft;

        if (touchingWallLeft || touchingWallRight)
        {
            anim.SetBool("cling", isTouchingWall);
            canDoubleJump = true;

            if (coyoteTimeEnabled)
            {
                coyoteTimer = coyoteTime;
            }
        }
        else if (!touchingWallLeft && !touchingWallRight)
        {
            anim.SetBool("cling", isTouchingWall);
            if (coyoteTimeEnabled)
            {
                coyoteTimer -= Time.deltaTime;
            }
        }
    }


    void HandleMovement()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)
            facingDirection = 1;
        else if (moveInput < 0)
            facingDirection = -1;
        transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Ground Jump or Coyote Jump
            if (isGrounded || (coyoteTimeEnabled && coyoteTimer > 0))
            {
                Jump();
                isTouchingWall = false;
            }
            // Wall Jump
            else if (wallJumpEnabled && (touchingWallLeft || touchingWallRight))
            {
                WallJump();

            }
            // Double Jump
            else if (doubleJumpEnabled && canDoubleJump)
            {
                Jump();
                canDoubleJump = false;

            }
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }


    void WallJump()
    {
        if (touchingWallLeft)
        {
            rb.linearVelocity = new Vector2(facingDirection * wallJumpForceX, wallJumpForceY);
            
        }
        else if (touchingWallRight)
        {
            rb.linearVelocity = new Vector2(-facingDirection * wallJumpForceX, wallJumpForceY);
            facingDirection = -facingDirection;

        }
    }


    void HandleDash()
    {
        if (!dashEnabled) return;

        dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }
    }

    System.Collections.IEnumerator Dash()
    {
        isDashing = true;

        dashCooldownTimer = dashCooldown;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        rb.linearVelocity = new Vector2(facingDirection * dashSpeed, 0);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;

        isDashing = false;
    }
}
