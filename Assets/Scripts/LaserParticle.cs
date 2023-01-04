using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticle : MonoBehaviour
{
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);
        int i = 0;
        print(numCollisionEvents);
        while (i < numCollisionEvents)
        {
            Debug.Log("YOU HIT THE TRIGGER WITH THE POWER!!!");
            i++;
        }
    }
}
