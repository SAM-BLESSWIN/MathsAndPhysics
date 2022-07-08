using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Powers
{
    public static int SPEED = 1; //(2^0)
    public static int MAGIC = 2;//(2^1)
    public static int STRENGTH = 4; //(2^2)
    public static int INVISIBLE = 8; //(2^3)
}

public class SetPowers : MonoBehaviour
{
    [SerializeField]
    [ReadOnlyInspector]
    private int myPowers;

    [SerializeField]
    [ReadOnlyInspector]
    private string myPowersBinary;

    private bool canAddPowers = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canAddPowers)
            Addpower(other.gameObject);
        else
            RemovePower(other.gameObject);

        myPowersBinary = Convert.ToString(myPowers, 2).PadLeft(4, '0');
        Debug.Log(myPowersBinary);
    }

    private void Addpower(GameObject other)
    {
        if (other.CompareTag("strength"))
            myPowers |= Powers.STRENGTH;
        if (other.CompareTag("speed"))
            myPowers |= Powers.SPEED;
        if (other.CompareTag("magic"))
            myPowers |= Powers.MAGIC;
        if (other.CompareTag("invisible"))
            myPowers |= Powers.INVISIBLE;
    }

    private void RemovePower(GameObject other)
    {
        if (other.CompareTag("strength"))
            myPowers &= ~Powers.STRENGTH;
        if (other.CompareTag("speed"))
            myPowers &= ~Powers.SPEED;
        if (other.CompareTag("magic"))
            myPowers &= ~Powers.MAGIC;
        if (other.CompareTag("invisible"))
            myPowers &= ~Powers.INVISIBLE;
    }

    public void AddPowersMode(bool value)
    {
        canAddPowers = value;
    }
}
