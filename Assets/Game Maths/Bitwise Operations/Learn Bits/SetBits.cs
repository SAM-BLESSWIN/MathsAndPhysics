using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetBits : MonoBehaviour
{
    public int value = 10;
    public String binary;

    private void Update()
    {
        binary = Convert.ToString(value, 2).PadLeft(8,'0');
    }
}
