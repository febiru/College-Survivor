using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collide : MonoBehaviour
{
    public float steerSpeed = 0.5f;
    public float moveSpeed = 0.1f;
    [SerializeField] Color ColRectColor = new Color(0, 0, 1, 1);
    [SerializeField] Color ColCirColor = new Color(0, 1, 0, 1);
    [SerializeField] Color ColNexColor = new Color(0, 1, 1, 0);
    SpriteRenderer spriteRenderer;

    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderLine")
        {
            Debug.Log("Rectangle is Collide!");
            spriteRenderer.color = ColRectColor;
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.tag == "Next")
        {
            Debug.Log("Circle is Collide!");
            spriteRenderer.color = ColNexColor;
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Circle is Collide!");
            spriteRenderer.color = ColCirColor;
            if (Text != null)
            {
                Text.SetActive(true);
            }
        }
    }
}
