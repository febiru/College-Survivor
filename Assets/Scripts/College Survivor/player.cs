using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Movement
    public float speed;
    Animator animations;

    // Sprite
    SpriteRenderer spriteRenderer;
    private Color originalColor;

    // Dash
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    // Health
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    // UI
    public GameOver gameOverScreen;

    // Collider + invulnerability
    private Collider2D playerCollider;
    private bool colliderOriginallyEnabled = true;
    public bool IsInvulnerable { get; private set; } = false;

    // Trail (assign in Inspector or it will try to get one from the GameObject)
    public TrailRenderer dashTrail;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        animations = GetComponent<Animator>();
        activeMoveSpeed = speed;
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.SetMaxHealth(maxHealth);

        // cache collider
        playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null)
            colliderOriginallyEnabled = playerCollider.enabled;

        // try to auto-cache a TrailRenderer if none assigned
        if (dashTrail == null)
            dashTrail = GetComponent<TrailRenderer>();

        // ensure trail is off initially
        if (dashTrail != null)
            dashTrail.emitting = false;
    }

    void Update()
    {
        // Movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveX = h * activeMoveSpeed * Time.deltaTime;
        float moveY = v * activeMoveSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);

        float inputMagnitude = Mathf.Abs(h) + Mathf.Abs(v);
        if (inputMagnitude == 0)
            animations.SetFloat("Speed", 0);
        else
            animations.SetFloat("Speed", 1);

        // Dash start
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCoolCounter <= 0f && dashCounter <= 0f)
        {
            StartDash();
        }

        // Dash timing
        if (dashCounter > 0f)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0f)
            {
                EndDash();
            }
        }

        if (dashCoolCounter > 0f)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void StartDash()
    {
        activeMoveSpeed = dashSpeed;
        dashCounter = dashLength;

        // make player immune to collisions/triggers while dashing
        IsInvulnerable = true;
        if (playerCollider != null)
            playerCollider.enabled = false;

        // flash sprite white
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white;

        // enable trail (clear previous trail first)
        if (dashTrail != null)
        {
            dashTrail.Clear();
            dashTrail.emitting = true;
        }
    }

    void EndDash()
    {
        activeMoveSpeed = speed;
        dashCoolCounter = dashCooldown;

        // restore collider and invulnerability
        IsInvulnerable = false;
        if (playerCollider != null)
            playerCollider.enabled = colliderOriginallyEnabled;

        // stop trail emitting (trail will fade out visually based on its time)
        if (dashTrail != null)
            dashTrail.emitting = false;

        // restore sprite color
        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }

    // Health
    public void TakeDamage(int damage)
    {
        // optional extra check to ignore damage while invulnerable
        if (IsInvulnerable) return;

        currentHealth -= damage;
        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            if (gameOverScreen != null)
                gameOverScreen.Setup();

            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        // safety: ensure collider is restored if object disabled/destroyed mid-dash
        if (playerCollider != null)
            playerCollider.enabled = colliderOriginallyEnabled;

        if (dashTrail != null)
            dashTrail.emitting = false;

        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }
}