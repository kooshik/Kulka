using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public Vector3 target;

    public Transform tip;
    public GameObject clonePrefab;
    public Transform cloneParent;

    // Use this for initialization
    void Start()
    {
        UpdateTarget();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(target.x - transform.position.x) < 0.1f)
            UpdateTarget();

        GetComponent<Rigidbody>().velocity *= 0.5f;
        GetComponent<Rigidbody>().velocity += (target - transform.position) * 0.8f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball") && collision.relativeVelocity.sqrMagnitude > 6f)
        {
            GameObject step = Instantiate(clonePrefab, tip.position, Quaternion.identity, cloneParent);

            Vector3 scale = step.transform.localScale;
            scale.x = collision.relativeVelocity.magnitude / 8;
            step.transform.localScale = scale;

            step.GetComponent<Rigidbody>().mass = 128 * collision.relativeVelocity.magnitude / 8;

            step.SetActive(true);
            UpdateTarget();
        }
    }

    public void UpdateTarget()
    {
        target = Random.onUnitSphere * 6;
        target.z = 4;
        target.y += 3.6f;

        if (target.x < 0)
            target.x -= 5;
        else
            target.x += 5;

        if (target.y < 0.4f)
            target.y = 0.4f;
    }

}
