using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    SpriteRenderer healthBarSprite;
    public int MaxHealth = 100;
    private int CurrHealth;
    public float healthBarScale = 1.9f;

    void Start()
    {
        CurrHealth = MaxHealth;
        Transform bar = transform.Find("HealthBar");

        if (bar != null)
        {
            healthBarSprite = bar.GetComponent<SpriteRenderer>();
            Debug.Log("HealthBar");

            Vector3 scale = healthBarSprite.transform.localScale;
            scale.x = healthBarScale;
            healthBarSprite.transform.localScale = scale;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
