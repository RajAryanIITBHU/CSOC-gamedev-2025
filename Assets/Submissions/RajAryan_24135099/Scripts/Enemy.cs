using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    SpriteRenderer healthBarSprite;

    public int MaxHealth = 100;
    private int CurrHealth;
    public float healthBarScale = 0.85f;

    public float moveSpeed = 2f;
    public Transform player; 

    void Start()
    {
        CurrHealth = MaxHealth;

        Transform bar = transform.Find("HealthBar");
       
        if (bar != null)
        {
            healthBarSprite = bar.GetComponent<SpriteRenderer>();

            Vector3 scale = healthBarSprite.transform.localScale;
            scale.x = healthBarScale;
            healthBarSprite.transform.localScale = scale;

        }

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.collider.GetComponent<Bullet>();

        if (bullet != null)
        {
            Debug.Log("Bullet damage: " + bullet.damage);
            TakeDamage(bullet.damage);
            Destroy(bullet.gameObject);
        }

    }

    void TakeDamage(int damage)
    {
        CurrHealth = Mathf.Max(CurrHealth - damage, 0);

        float percent = (float)CurrHealth / MaxHealth;

        Vector3 scale = healthBarSprite.transform.localScale;
        scale.x = healthBarScale * percent;
        healthBarSprite.transform.localScale = scale;

        if (CurrHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
