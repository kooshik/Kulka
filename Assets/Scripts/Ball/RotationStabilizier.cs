using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStabilizier : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
