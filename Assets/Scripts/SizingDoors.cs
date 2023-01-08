using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizingDoors : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collide(other.gameObject);
    }

    private void Collide(GameObject collidedObject)
    {
        BallSizeGate ball = collidedObject.GetComponent<BallSizeGate>();

        if (ball)
        {
            ball.ChangeSize();
        }
    }
}
