using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float timer;
    public bool isMoveRight;
    public Rigidbody2D rig;
    public float bulletSpeed = 20f;

    void Start()
    {
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveRight)
        {
            rig.velocity = new Vector2(bulletSpeed, 0);
        }

        else
        {
            rig.velocity = new Vector2(-bulletSpeed, 0);
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Destroy(this.gameObject);
            timer = 3f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
