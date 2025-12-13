using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        int randomValueX = Mathf.FloorToInt(Random.Range(1, 255));
        int randomValueY = Mathf.FloorToInt(Random.Range(1, 255));
        int randomValueZ = Mathf.FloorToInt(Random.Range(1, 255));
        //player.GetComponent<SpriteRenderer>().color = new Color(randomValueX, randomValueY, randomValueZ);
        player.GetComponent<SpriteRenderer>().color = new Color32((byte)randomValueX, (byte)randomValueY, (byte)randomValueZ, 255);
        Debug.Log("Red: " + randomValueX + ", Green: " + randomValueY + ", Blue: " + randomValueZ);

        
    }
}
