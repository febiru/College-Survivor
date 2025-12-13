using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Projectile; // consider renaming to projectilePrefab
    public float speed = 10f;
    public AudioSource audioSource;
    public AudioClip shootAudioClip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogWarning("No Camera tagged MainCamera found.");
            return;
        }

        audioSource.PlayOneShot(shootAudioClip);

        Vector3 mousePos = Input.mousePosition;
        // Ensure correct Z distance for ScreenToWorldPoint (works for perspective and orthographic)
        mousePos.z = Mathf.Abs(cam.transform.position.z - transform.position.z);

        Vector3 worldMouse = cam.ScreenToWorldPoint(mousePos);
        Vector2 shootDirection = (worldMouse - transform.position).normalized;

        GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * speed;
        }
        else
        {
            Debug.LogWarning("Projectile prefab missing Rigidbody2D component.");
        }

        // Optional: rotate projectile to face travel direction
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Destroy(projectile, 2f);
    }
}
