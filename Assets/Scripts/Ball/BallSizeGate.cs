using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeGate : Ball
{
    private float changingSizeTime;
    private bool sizeChanged = false;
    private bool changingSize;
    private Vector3 endSize;
    private Vector3 startSize;

    private Vector3 smallSize = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 normalSize = new Vector3(1f, 1f, 1f);

    protected override void Update()
    {
        base.Update();

        if (changingSize)
        {
            if (changingSizeTime < 1f)
            {
                changingSizeTime += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startSize, endSize, changingSizeTime / 1f);
            }
            else
            {
                transform.localScale = endSize;
                changingSize = false;
            }
        }
    }

    public void ChangeSize()
    {
        changingSizeTime = 0f;
        changingSize = true;

        if (sizeChanged)
        {
            startSize = transform.localScale;
            endSize = normalSize;
            myRigidbody.mass = 1f;
        }
        else
        {
            startSize = transform.localScale;
            endSize = smallSize;
            myRigidbody.mass = 0.0001f;
        }

        sizeChanged = !sizeChanged;
    }
}
