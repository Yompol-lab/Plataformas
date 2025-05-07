using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public LayerMask wallLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private bool onWallLeft;
    private bool onWallRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        Move();
        Jump();
 
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rb.linearVelocity = velocity;
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        onWallLeft = Physics.CheckSphere(wallCheckLeft.position, 0.2f, wallLayer);
        onWallRight = Physics.CheckSphere(wallCheckRight.position, 0.2f, wallLayer);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else if (onWallLeft)
            {
                Vector3 jumpDirection = Vector3.up + Vector3.right;
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse);
            }
            else if (onWallRight)
            {
                Vector3 jumpDirection = Vector3.up + Vector3.left;
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
