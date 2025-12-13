using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan3C : MonoBehaviour
{
    public int a;

    [SerializeField][Range(1, 10)] int b;


    [Header("Data Diri")]
    [SerializeField] string nama;
    [SerializeField] int nim;
    [SerializeField][TextArea(3, 5)] string kesan; 
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
