using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float wallJumpHorizontalForce = 5f;

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
        // Revisamos contacto con el suelo y paredes
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        onWallLeft = Physics.CheckSphere(wallCheckLeft.position, 0.2f, wallLayer);
        onWallRight = Physics.CheckSphere(wallCheckRight.position, 0.2f, wallLayer);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                // Salto normal desde el suelo
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else if (onWallLeft)
            {
                // Salto desde pared izquierda (hacia la derecha)
                Vector3 jumpDir = Vector3.up + Vector3.right;
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(jumpDir.normalized * jumpForce + Vector3.right * wallJumpHorizontalForce, ForceMode.Impulse);
            }
            else if (onWallRight)
            {
                // Salto desde pared derecha (hacia la izquierda)
                Vector3 jumpDir = Vector3.up + Vector3.left;
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(jumpDir.normalized * jumpForce + Vector3.left * wallJumpHorizontalForce, ForceMode.Impulse);
            }
        }
    }
}
