using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan4 : MonoBehaviour
{
    int[] deret1 = new int[10];

    [SerializeField] string[] kata1 = new string[3];
    [SerializeField] string[] kata2 = { "satu", "dua", "tiga" };

    // Start is called before the first frame update
    void Start()
    {
        kata1[2] = "Testing";
        Debug.Log(kata1[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
