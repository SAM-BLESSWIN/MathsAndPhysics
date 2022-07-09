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
        myKeysBinary = Convert.ToString(myKeys, 2).PadLeft(4, '0');
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
                myKeys |= PowerofTwo((int)Keys.RED);
                other.SetActive(false);
                break;
            case "yellow":
                myKeys |= PowerofTwo((int)Keys.YELLOW);
                other.SetActive(false);
                break;
            case "blue":
                myKeys |= PowerofTwo((int)Keys.BLUE);
                other.SetActive(false);
                break;
            case "green":
                myKeys |= PowerofTwo((int)Keys.GREEN);
                other.SetActive(false);
                break;
        }
    }

    private int PowerofTwo(int position)
    {                                        // 8     4    2    1          
        return (int)Mathf.Pow(2, position);  //2^3   2^2  2^1  2^0
    }

    public void DropRedKey(GameObject keyObject)
    {
        myKeys &= ~PowerofTwo((int)Keys.RED);
        keyObject.SetActive(true);
    }

    public void DropYellowKey(GameObject keyObject)
    {
        myKeys &= ~PowerofTwo((int)Keys.YELLOW);
        keyObject.SetActive(true);
    }

    public void DropBlueKey(GameObject keyObject)
    {
        myKeys &= ~PowerofTwo((int)Keys.BLUE);
        keyObject.SetActive(true);
    }

    public void DropGreenKey(GameObject keyObject)
    {
        myKeys &= ~PowerofTwo((int)Keys.GREEN);
        keyObject.SetActive(true);
    }

}
