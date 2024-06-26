using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        
        // กระโดดแบบโพรเจกไทล์โดยกด Ctrl
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            ProjectileJump();
        }
    }
    
    private void ProjectileJump()
    {
        // คำนวณความเร็วแนวดิ่งที่ต้องการกระโดด
        float jumpVelocity = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpForce);

        // ใช้ความเร็วแนวดิ่งที่คำนวณไว้ในการกระโดด
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }
    
    // ตรวจสอบการชน ITEM แล้วขึ้นคะแนน OnCollisionEnter2D
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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