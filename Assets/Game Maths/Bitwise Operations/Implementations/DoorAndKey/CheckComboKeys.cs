using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckComboKeys : MonoBehaviour
{
    [SerializeField] private List<Keys> Doorkeys = new List<Keys>();
    [SerializeField] private GameObject lockGameObject;

    [SerializeField][ReadOnlyInspector]
    private string keyBinary;

    private int keyValue = 0;

    private void Start()
    {
        foreach (Keys key in Doorkeys)
        {
            keyValue |= MathLib.SetBitPosition((int)key);
        }

        keyBinary = MathLib.IntToBinaryForm(keyValue,4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (other.gameObject.TryGetComponent<SetKeys>(out var setKeys))
        {
            foreach (Keys key in Doorkeys)
            {
                if ((setKeys.MyKeys & MathLib.SetBitPosition((int)key)) == 0) return;
            }
            lockGameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lockGameObject.SetActive(true);
    }
}
