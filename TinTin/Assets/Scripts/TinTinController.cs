using UnityEngine;

public class TinTinController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float maxHeight = 4f;
    [SerializeField] private float minHeight = -4f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int maxAmmo = 999;
    private int currentAmmo;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAmmo = maxAmmo;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if TinTin is on the ground
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // Jump on Space only
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // When landed set isJumping to false
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        // Clamp position so TinTin stays on screen
        float clampedY = Mathf.Clamp(
            transform.position.y,
            minHeight,
            maxHeight
        );
        transform.position = new Vector3(
            transform.position.x,
            clampedY,
            transform.position.z
        );

        // Shoot on LEFT mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            HealthManager.Instance.TakeDamage(20f);
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0) return;

        currentAmmo--;

        Vector3 spawnPos = transform.position + new Vector3(5f, 0f, 0f);

        Instantiate(
            projectilePrefab,
            spawnPos,
            Quaternion.identity
        );
    }
}