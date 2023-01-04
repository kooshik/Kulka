using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int triggerCounter;

    private void OnTriggerEnter(Collider other)
    {
        triggerCounter++;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerCounter--;
    }
}
