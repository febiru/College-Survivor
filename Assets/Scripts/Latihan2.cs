using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan2 : MonoBehaviour
{
    int n = 5;
    double d = 7 / 2;
    string kata = "Dunia";

    void Start()
    {
        Debug.Log(n + 2);
        Debug.Log(n + n);
        Debug.Log(d);

        d = 7 / 2.0;
        Debug.Log(d);

        Debug.Log("Halo " + kata);
        Debug.Log("Hasil " + n + 2);
        Debug.Log("Hasil " + (n + 2));
    }

    void Update()
    {
        
    }
}
