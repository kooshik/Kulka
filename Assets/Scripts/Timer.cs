using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimer;
    public TextMesh text;

    public float totalTime = 100;
    private float startTime;

    public bool executed = false;

    public float RemainingTime
    {
        get
        {
            return totalTime - (Time.time - startTime);
        }
    }

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        float current = RemainingTime;

        if (current < 0)
        {
            current = 0;

            if (!executed)
            {
                executed = true;

                if (OnTimer != null)
                    OnTimer.Invoke();
            }
        }

        text.text = ((int)current).ToString();
    }

    public void Reset()
    {
        startTime = Time.time;
        executed = false;
    }
}
