using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    public GameObject Particles;
    public Rigidbody Rigidbody;

    public void Annihilate()
    {
        GameObject temp = Instantiate(Particles, transform.position, transform.rotation);
        Destroy(temp, 1);
        gameObject.SetActive(false);    
    }
}
