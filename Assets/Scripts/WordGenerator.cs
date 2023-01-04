using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject prefab;
    public float delay;

    private float timer;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer + delay)
        {
            timer = Time.time;
            GameObject wordUp = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity, transform);

            string s = string.Empty;
            int len = Random.Range(1, 10);

            for (int n = 0; n < len; n++)
                s += n.ToString();

            wordUp.GetComponent<TextMesh>().text = s;
            wordUp.AddComponent<BoxCollider>();
            wordUp.GetComponent<BoxCollider>().size = wordUp.GetComponent<BoxCollider>().size + Vector3.forward;
        }

        transform.position += Vector3.left * Time.deltaTime * 2;
    }
}
