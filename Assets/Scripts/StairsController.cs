using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{

    public Camera cam;
    public Gradient background;
    public Transform ball;
    public MeshRenderer floor;

    // Use this for initialization
    void Start()
    {
        cam.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        floor.enabled = ball.position.y < 0.5f;

        float height = ball.position.y - 0.5f;

        if (height > 6f)
            height = 6f;

        if (height < 0)
            height = 0;

        // convert height to weight :)
        height = 1 - (height / 6f);

        cam.backgroundColor = background.Evaluate(height);
    }
}
