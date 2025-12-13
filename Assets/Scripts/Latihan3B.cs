using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan3B : MonoBehaviour
{
    public int a;

    [SerializeField][Range(1, 10)] int b;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(a + b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
