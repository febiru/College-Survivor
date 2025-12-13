using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public int ScoreValue = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Public method to receive damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        if (HighScore.Instance != null)
            HighScore.Instance.AddScore(ScoreValue);

        Destroy(gameObject);
    }

    // Existing movement/collision code below (keep or merge with your current logic)
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.freezeRotation = true;
    }

    void Update()
    {
        if (player == null)
        {
            movement = Vector2.zero;
            return;
        }

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        if (rb != null) rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerScript = collision.GetComponent<player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}