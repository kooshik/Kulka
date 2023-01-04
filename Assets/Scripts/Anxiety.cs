using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anxiety : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Ball.constrainLeftRight = true;
    }
}
