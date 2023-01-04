using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAspect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float size = 9f / 16f * cam.aspect;


        if (size < 1)
        {
            cam.rect = new Rect(0, (1 - size) / 2, 1, size);
        }
    }
}
