using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    [SerializeField] private Keys doorKey;
    [SerializeField] private GameObject lockGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (other.gameObject.TryGetComponent<SetKeys>(out var setKeys))
        {

            if ((setKeys.MyKeys & (1 << (int)doorKey)) != 0)
            {
                Debug.Log("Have Key");
                lockGameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lockGameObject.SetActive(true);
    }
}
