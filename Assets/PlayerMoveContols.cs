
using UnityEngine;

public class PlayerMoveContols : MonoBehaviour
{
    public float Speed = 5f;
    public float jumpForce = 10f;

    public float rayLength = 0.3f;

    public LayerMask GroundLayer;
    public Transform LeftPoint;
    public Transform RightPoint;

    private Rigidbody2D rb;
    private Gatherinput gatherInput;
    private Animator animator;

    private int direction = 1;
    private bool grounded = false;

    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gatherInput = GetComponent<Gatherinput>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (LeftPoint == null)
            Debug.LogWarning("LeftPoint is not assigned!");
        if (RightPoint == null)
            Debug.LogWarning("RightPoint is not assigned!");
    }

    void FixedUpdate()
    {
        CheckStatus();
        Move();
        JumpPlayer();
    }

    private void Move()
    {
        if (gatherInput == null) return;

        Flip();
        Vector2 vel = rb.linearVelocity;
        vel.x = gatherInput.valueX * Speed;
        rb.linearVelocity = vel;
    }

    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            Vector3 s = transform.localScale;
            s.x = -s.x;
            transform.localScale = s;
            direction *= -1;
        }
    }

    private void JumpPlayer()
    {
        if (gatherInput.jumpInput)
        {
            rb.linearVelocity = new Vector2(gatherInput.valueX * Speed, jumpForce);
        }
        gatherInput.jumpInput = false;
    }

    private void CheckStatus()
{
    RaycastHit2D leftCheckHit = Physics2D.Raycast(LeftPoint.position, Vector2.down, rayLength, GroundLayer);
    grounded = leftCheckHit;

    RaycastHit2D rightCheckHit = Physics2D.Raycast(RightPoint.position, Vector2.down, rayLength, GroundLayer);
    grounded |= rightCheckHit;
}

    private void SetAnimatorValues()
    {
        
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("Vspeed", rb.linearVelocity.y);
        animator.SetBool("Grounded", true);
    
    }

    void Update()
    {
        CheckStatus();
        SetAnimatorValues();
        Flip();
        rb.velocity = new Vector2(gatherInput.valueX * Speed, rb.velocity.y);
        JumpPlayer();
    }
}