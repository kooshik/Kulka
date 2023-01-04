using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvader : MonoBehaviour
{
    public bool isKinematic = true;
    public SpaceDispatcher dispatcher;

    private void OnParticleCollision(GameObject other)
    {
        Collide();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11 && isKinematic)
            dispatcher.RestartLevel();

        Collide();
    }

    private void Collide()
    {
        isKinematic = false;
        GetComponent<MeshRenderer>().material.color = Color.red;
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.8f);

        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        //transform.GetChild(1).GetComponent<ParticleSystem>().Play();

        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, 2f);
    }
}
