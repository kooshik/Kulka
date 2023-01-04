using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTouch : MonoBehaviour
{
    public GameObject endScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
            endScreen.SetActive(true);
    }
}
