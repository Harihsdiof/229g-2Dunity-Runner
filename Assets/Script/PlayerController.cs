using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // ไม่ Flip ภาพ
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Flip ภาพ
        }

        // ตรวจสอบการกระโดด
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบการชนกับพื้น
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ตรวจสอบเมื่อไม่มีการชนกับพื้น
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = false;
        }
    }
}