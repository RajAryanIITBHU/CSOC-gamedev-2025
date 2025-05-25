using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public float destroyBullet = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, destroyBullet);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bullet hit: " + collision.collider.name);
        Destroy(gameObject,2f);
    }
}
