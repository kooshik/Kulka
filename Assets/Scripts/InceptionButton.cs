using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InceptionButton : MonoBehaviour
{
    public enum ButtonType { Left, Up, Right };

    public ButtonType buttonType;
    public Rigidbody ball;

    private void OnCollisionEnter(Collision collision)
    {
        switch (buttonType)
        {
            case ButtonType.Left:
                ball.AddForce(Vector3.left * 64 * 10, ForceMode.Force);
                break;
            case ButtonType.Up:
                if (IsGrounded())
                    ball.AddForce(Vector3.up * 64 * 20, ForceMode.Force);
                break;
            case ButtonType.Right:
                ball.AddForce(Vector3.right * 64 * 10, ForceMode.Force);
                break;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(ball.transform.position, Vector3.down, transform.localScale.y + 0.0001f);
    }
}