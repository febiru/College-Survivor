using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan1B : MonoBehaviour
{
    byte varByte = 123;
    short varShort = 123;
    private string varLokal;
    int varInt;
    long varLong = 123;

    float varFloat = 1.23f;
    double varDouble = 1.23d;

    bool varBoolean = true;

    string varChar = "U";
    string varString = "Unity";

    void Start()
    {
        string varLokal = "Lokal";
        varLokal = "Variabel Lokal";

        varInt = 123;
        Debug.Log(varInt);
    }

    void Update()
    {
        
    }
}
