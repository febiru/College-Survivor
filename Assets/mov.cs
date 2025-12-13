using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public float steerSpeed = 0.5f;
    public float moveSpeed = 0.1f;
    public GameObject destroy;
    public GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == destroy)
        {
            Destroy(destroy);
        }
        if (collision.gameObject == explode)
        {
            Destroy(explode);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Square dilewati oleh player");
    }
}
