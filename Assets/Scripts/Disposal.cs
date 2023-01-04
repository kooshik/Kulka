using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disposal : MonoBehaviour
{
    public GameObject[] objects;
    private int counter = 0;

    public void Dispose()
    {
        if (counter < objects.Length)
        {
            objects[counter].SetActive(true);
            counter++;
        }
    }

    public void Reset()
    {
        counter = 0;

        for (int n = 0; n < objects.Length; n++)
            objects[n].SetActive(false);
    }
}
