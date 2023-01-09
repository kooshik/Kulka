using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeControl : Ball
{
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        FixedUpdateEsc();

        if (isActive)
        {
            FixedUpdateUpDown(); // koshik: to be overriden & placed in Update()
            FixedUpdateLeftRight();
        }
    }
}
