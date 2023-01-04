using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightUpOnTouch : MonoBehaviour
{
    public bool ignoreFloor = true;
    public bool ignoreOtherBalls = false;
    public bool holdColor = false;

    public bool alphaOnly = false;
    public bool invokeOnStay = false;

    public Color highlightColor = Color.yellow;

    public UnityEvent OnTouch;

    private Color targetColor;

    private void Start()
    {
        targetColor = GetComponent<MeshRenderer>().material.color;
    }

    public void Collide()
    {
        GetComponent<MeshRenderer>().material.color = highlightColor;
    }

    private void Collide(GameObject other)
    {
        if (!(ignoreFloor && other.layer == 8) && !(ignoreOtherBalls && other.layer == 11))
            Collide();
    }

    private void OnTriggerEnter(Collider other)
    {
        Collide(other.gameObject);

        if (OnTouch != null)
            OnTouch.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        Collide(collision.gameObject);

        if (OnTouch != null)
            OnTouch.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        Collide(collision.gameObject);

        if (invokeOnStay && OnTouch != null)
            OnTouch.Invoke();
    }

    private void FixedUpdate()
    {
        if (!holdColor)
            if (alphaOnly)
            {
                Color col = GetComponent<MeshRenderer>().material.color;
                col.a *= 0.95f;
                GetComponent<MeshRenderer>().material.color = col;
            }
            else
                GetComponent<MeshRenderer>().material.color = (0.95f * GetComponent<MeshRenderer>().material.color + 0.05f * targetColor);
    }

    public void SetTargetColor(Color targetNew)
    {
        targetColor = targetNew;
    }
}
