using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    public bool isActive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (isActive)
        {
            if (collision.gameObject.layer == 9)
            {
                GameManager.Instance.Ball.GetComponent<Ball>().Boooom();
                GameManager.Instance.RestartLevel();
            }
            else
            {
                if (collision.gameObject.layer == 11)
                {
                    collision.gameObject.GetComponent<OtherBall>().Annihilate();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.layer == 9)
            {
                GameManager.Instance.Ball.GetComponent<Ball>().Boooom();
                GameManager.Instance.RestartLevel();
            }
            else
            {
                if (other.gameObject.layer == 11)
                {
                    other.gameObject.GetComponent<OtherBall>().Annihilate();
                }
            }
        }
    }
}
