using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private int jumpCount;
    private bool jumpRequested;
    private bool jumpCutRequested;

    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    private float facingDirection = 1f;
    public float FacingDirection => facingDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = 0f;
        if (AnyKeyHeld(playerData.LeftKeys))
        {
            horizontalInput -= 1f;
        }

        if (AnyKeyHeld(playerData.RightKeys))
        {
            horizontalInput += 1f;
        }

        if (AnyKeyDown(playerData.JumpKeys))
        {
            jumpRequested = true;
        }

        if (AnyKeyUp(playerData.JumpKeys))
        {
            jumpCutRequested = true;
        }

        if(horizontalInput != 0f)
        {
            facingDirection = horizontalInput;
            spriteRenderer.flipX = facingDirection < 0f;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        Move();
        Jump();
        CutJump();
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerData.GroundCheckRadius, groundLayer) != null;

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            jumpCount = 0;
        }
        else if (!isGrounded && jumpCount == 0)
        {
            jumpCount = 1;
        }
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(horizontalInput * playerData.MoveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (jumpRequested && jumpCount < playerData.MaxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * playerData.JumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
        jumpRequested = false;
    }

    private void CutJump()
    {
        if (jumpCutRequested && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * playerData.JumpCutMultiplier);
        }
        jumpCutRequested = false;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck == null || playerData == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, playerData.GroundCheckRadius);
    }

    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }

    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key)) return true;
        }
        return false;
    }

    private bool AnyKeyUp(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyUp(key)) return true;
        }
        return false;
    }
}
