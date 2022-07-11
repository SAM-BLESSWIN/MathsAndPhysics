using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Keys
{
     RED,
     YELLOW,
     BLUE,
     GREEN
}

public class SetKeys : MonoBehaviour
{
    [SerializeField]
    [ReadOnlyInspector]
    private int myKeys; 
    public int MyKeys { get { return myKeys; } }

    [SerializeField]
    [ReadOnlyInspector]
    private string myKeysBinary;

    [SerializeField] private TMPro.TMP_Text myKeysBinaryText;

    private void Update()
    {
        myKeysBinary = MathLib.IntToBinaryForm(myKeys,4);
        myKeysBinaryText.text = myKeysBinary;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddKey(other.gameObject);
    }

    private void AddKey(GameObject other)
    {
        switch (other.tag)
        {
            case "red":
                myKeys |= MathLib.SetBitPosition((int)Keys.RED);
                other.SetActive(false);
                break;
            case "yellow":
                myKeys |= MathLib.SetBitPosition((int)Keys.YELLOW);
                other.SetActive(false);
                break;
            case "blue":
                myKeys |= MathLib.SetBitPosition((int)Keys.BLUE);
                other.SetActive(false);
                break;
            case "green":
                myKeys |= MathLib.SetBitPosition((int)Keys.GREEN);
                other.SetActive(false);
                break;
        }
    }

    public void DropRedKey(GameObject keyObject)
    {
        myKeys &= ~MathLib.SetBitPosition((int)Keys.RED);
        keyObject.SetActive(true);
    }

    public void DropYellowKey(GameObject keyObject)
    {
        myKeys &= ~MathLib.SetBitPosition((int)Keys.YELLOW);
        keyObject.SetActive(true);
    }

    public void DropBlueKey(GameObject keyObject)
    {
        myKeys &= ~MathLib.SetBitPosition((int)Keys.BLUE);
        keyObject.SetActive(true);
    }

    public void DropGreenKey(GameObject keyObject)
    {
        myKeys &= ~MathLib.SetBitPosition((int)Keys.GREEN);
        keyObject.SetActive(true);
    }

}
