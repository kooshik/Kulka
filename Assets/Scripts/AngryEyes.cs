using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEyes : MonoBehaviour
{

    public TextMesh text;
    public string textDefault;
    public string textBlink;

    public float timeDefault = 4f;
    public float timeBlink = 0.06f;
    private float timer;

    private void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (text.text == textDefault && Time.time > timer + timeDefault)
        {
            text.text = textBlink;
            timer = Time.time;
        }

        if (text.text == textBlink && Time.time > timer + timeBlink)
        {
            text.text = textDefault;
            timer = Time.time;
        }
    }
}
