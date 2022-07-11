using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitPacking : MonoBehaviour
{
    public string A = "1101111";
    [ReadOnlyInspector]
    public UInt32 aBits;

    public string B = "10001";
    [ReadOnlyInspector]
    public UInt32 bBits;

    public string C = "1101";
    [ReadOnlyInspector]
    public UInt32 cBits;

    [ReadOnlyInspector]
    public UInt32 packed = 0;
    [ReadOnlyInspector]
    public string packedBinary;

    private void Start()
    {
        aBits = Convert.ToUInt32(A, 2);
        bBits = Convert.ToUInt32(B, 2);
        cBits = Convert.ToUInt32(C, 2);

        packed |= (aBits << (sizeof(UInt32) * 8 - A.Length));
        packed |= (bBits << (sizeof(UInt32) * 8 - (A.Length + B.Length)));
        packed |= (cBits << (sizeof(UInt32) * 8 - (A.Length + B.Length + C.Length)));

        packedBinary = MathLib.IntToBinaryForm(packed, 32);
    }

}
