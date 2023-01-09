using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeControl : Ball
{
    private float[] sizeList = new float[] { 0.5f, 1, 2, 4, 8 };
    private int sizeId = 1;

    protected override void Update()
    {
        base.Update();

        UpdateUpDown();
    }

    protected override void FixedUpdate()
    {
        FixedUpdateEsc();

        if (isActive)
        {
            //FixedUpdateUpDown();
            FixedUpdateLeftRight();
        }
    }

    private void UpdateUpDown()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (sizeId < sizeList.Length - 1)
                sizeId++;

            UpdateSize();

            if (IsGrounded())
                GetComponent<Rigidbody>().AddForce(Vector3.up * power * jumpMultiplier * sizeList[sizeId], ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (sizeId > 0)
                sizeId--;

            UpdateSize();
        }
    }

    private void UpdateSize()
    {
        transform.localScale = Vector3.one * sizeList[sizeId];
        myRigidbody.mass = sizeList[sizeId];
    }
}
