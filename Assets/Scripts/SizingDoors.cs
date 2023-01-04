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
        Ball ball = collidedObject.GetComponent<Ball>();

        if(ball)
        {
            ball.ChangeSize();
        }
    }
}
