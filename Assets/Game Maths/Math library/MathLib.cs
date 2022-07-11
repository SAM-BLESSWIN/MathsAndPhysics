using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathLib : MonoBehaviour
{
    public static int SetBitPosition(int position)
    {                                            
        return 1<<position;                  //8 = 1<<3 = 1000
    }

    public static string IntToBinaryForm(int value,int length)
    {
        return Convert.ToString(value, 2).PadLeft(length, '0');
    }

    public static string IntToBinaryForm(UInt32 value, int length)
    {
        return Convert.ToString(value, 2).PadLeft(length, '0');
    }
}
