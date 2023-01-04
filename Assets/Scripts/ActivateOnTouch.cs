using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTouch : MonoBehaviour
{
    public GameObject target;
    public bool ignoreFloor = true;
    public bool activate = true;

    private void Collide(Collision collision)
    {
        if (ignoreFloor && collision.gameObject.layer != 8)
            target.SetActive(activate);
    }

    void OnCollisionEnter(Collision collision)
    {
        Collide(collision);
    }
}
