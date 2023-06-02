using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public static Action EndTriggerr;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndTriggerr.Invoke();
        }

    }
}
