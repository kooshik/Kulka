using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvadersStupidLaser : MonoBehaviour
{
    public Timer timer;
    public Color targetColor;

    void OnCollisionEnter(Collision collision)
    {
        LightUpOnTouch state = GetComponent<LightUpOnTouch>();

        if (state.enabled)
        {
            state.SetTargetColor(targetColor);

            if (timer.RemainingTime < 65 && Random.value < 0.06f)
                state.enabled = false;
        }
        else
        {
            state.GetComponent<MeshRenderer>().enabled = false;
            state.GetComponent<BoxCollider>().enabled = false;
            state.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            state.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
