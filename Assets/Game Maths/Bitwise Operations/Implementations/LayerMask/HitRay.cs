using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRay : MonoBehaviour
{
    public int layer = 9;
    public bool ignoreLayer;
    public int layerMask = 0;
    public string layerMaskBinary;

    void Update()
    {

        layerMask = ignoreLayer ? ~(1 << layer) : 1 << layer;

        layerMaskBinary = MathLib.IntToBinaryForm(layerMask, 32);

        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,Mathf.Infinity,layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance,Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.blue);
        }
    }
}
