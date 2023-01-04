using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTouch : MonoBehaviour
{
    public float yPos = 7;

    public void SetPos(GameObject gameObject)
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = yPos;
        gameObject.transform.position = pos;

        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 200, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        SetPos(collision.gameObject);
    }
}
