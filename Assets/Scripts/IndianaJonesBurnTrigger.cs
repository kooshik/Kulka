using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaJonesBurnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KillPlayerOnTouch killer = other.GetComponent<KillPlayerOnTouch>();

        if (killer != null)
        {
            killer.isActive = true;
            killer.GetComponent<MeshRenderer>().material.color = new Color(1, 0.1f, 0);
        }

        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            GameManager.Instance.Ball.GetComponent<Ball>().Boooom();
            GameManager.Instance.RestartLevel();
        }
    }
}
