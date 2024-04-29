using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform targetPoint;

    [SerializeField] private Rigidbody2D bulletPrefabs;
    public float cooldownTime = 1.0f; // เวลาคูลดาว (วินาที)
    private float lastShotTime = 0.0f; // เวลาที่ยิงครั้งล่าสุด


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Time.time >= lastShotTime + cooldownTime)
        {
            ShootBullet();
            lastShotTime = Time.time;
        }

    }

    Vector2 CalcuateProjectileVelocity(Vector2 origin ,Vector2 target, float t)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y)*t;
        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }

    void ShootBullet()
    {

        //fire with projectile
        Vector2 projectile = CalcuateProjectileVelocity(shootingPoint.position, targetPoint.position, 1f);
        Rigidbody2D firebullet = Instantiate(bulletPrefabs, shootingPoint.position, Quaternion.identity);
        firebullet.velocity = projectile;

    }
}
