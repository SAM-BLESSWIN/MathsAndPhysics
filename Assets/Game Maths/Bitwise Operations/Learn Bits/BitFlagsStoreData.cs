using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions
{
    public static int RUN=1; //(2^0)
    public static int JUMP = 2;//(2^1)
    public static int FLY = 4; //(2^2)
    public static int SHOOT = 8; //(2^3)
    public static int EAT = 16; //(2^4)
}

public class BitFlagsStoreData : MonoBehaviour
{
    public int myActions = Actions.RUN | Actions.FLY | Actions.SHOOT;
    public bool addJump;
    public bool removeJump;
    public string myActionsBinary;


    private void Update()
    {
        myActionsBinary = Convert.ToString(myActions, 2).PadLeft(5,'0'); //BinaryRepresentation

        if (addJump)
        {
            myActions |= Actions.JUMP;
            addJump = false;
        }


        if(removeJump)
        {
            myActions &= ~Actions.JUMP;
            removeJump = false;
        }
           
    }
}
