using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        // รับ Input จากผู้เล่น
        float moveInput = Input.GetAxisRaw("Horizontal");

        // คำนวณความเร็วและเปลี่ยนตำแหน่ง
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ทำการ Flip ตัวละคร
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    // ฟังก์ชันสำหรับ Flip ตัวละคร
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ฟังก์ชันที่เรียกเมื่อตัวละครชนกำแพง
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // หันตัวละครไปทางตรงข้าม
            Flip();
        }
    }
}