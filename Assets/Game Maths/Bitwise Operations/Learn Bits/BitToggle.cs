using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitToggle : MonoBehaviour
{
    public int myActions = Actions.RUN | Actions.FLY | Actions.SHOOT;
    public bool jump;
    public string myActionsBinary;


    private void Update()
    {
        myActionsBinary = MathLib.IntToBinaryForm(myActions, 4);
        if(jump)
        {
            myActions ^= Actions.JUMP;
            jump = false;
        }
    }
}
