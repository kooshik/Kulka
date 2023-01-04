using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerwithBalls : MonoBehaviour
{
    private Vector3 Ball1Pos;
    private Vector3 Ball2Pos;
    private Vector3 Ball3Pos;

    public List<OtherBall> Balls;

    private void Awake()
    {
        if (Balls != null)
        {
            Ball1Pos = Balls[0].transform.position;
            Ball2Pos = Balls[1].transform.position;
            Ball3Pos = Balls[2].transform.position;
        }
    }

    private void OnEnable()
    {
        gameObject.SetActive(true);
        Balls[0].transform.position = Ball1Pos;
        Balls[1].transform.position = Ball2Pos;
        Balls[2].transform.position = Ball3Pos;
        Balls[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
        Balls[1].GetComponent<Rigidbody>().velocity = Vector3.zero;
        Balls[2].GetComponent<Rigidbody>().velocity = Vector3.zero;
        Balls[0].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Balls[1].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Balls[2].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Balls[0].gameObject.SetActive(true);
        Balls[1].gameObject.SetActive(true);
        Balls[2].gameObject.SetActive(true);
    }
}
