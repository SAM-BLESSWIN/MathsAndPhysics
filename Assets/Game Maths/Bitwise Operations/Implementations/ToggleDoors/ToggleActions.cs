using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public static class Powers
{
    public static int STRENGTH = 1; //(2^0) //0001
    public static int HEALTH = 2;//(2^1)    //0010
}

public class ToggleActions : MonoBehaviour
{
    public int myactions;
    public TMP_Text myActionsBinary;

    private void Start()
    {
        myactions = 0;
    }

    private void Update()
    {
        myActionsBinary.text = MathLib.IntToBinaryForm(myactions, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "strength")
        {
            myactions ^= Powers.STRENGTH;
        }

        if(other.gameObject.tag == "health")
        {
            myactions ^= Powers.HEALTH;
        }

        if(other.gameObject.tag == "strength+health")
        {
            myactions ^= (Powers.STRENGTH | Powers.HEALTH);
        }

    }
}
