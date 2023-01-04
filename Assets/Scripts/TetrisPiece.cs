using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPiece : MonoBehaviour
{
    public bool gravity;
    public TetrisController controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("IgnoreWalls"))
            Drop();
    }

    public void Drop()
    {
        if (!gravity)
        {
            gravity = true;
            GetComponent<Rigidbody>().useGravity = true;
            controller.currentBlock = null;
        }
    }

    public void Turn()
    {
        this.transform.Rotate(new Vector3(0, 0, 90));
    }

    void Start()
    {
        gravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    public float GetLeftSqrPos()
    {
        float ret = float.MaxValue;

        foreach (Collider col in transform.GetComponentsInChildren<Collider>())
            if (col.bounds.min.x < ret)
                ret = col.bounds.min.x;

        return ret;
    }

    public float GetRightSqrPos()
    {
        float ret = float.MinValue;

        foreach (Collider col in transform.GetComponentsInChildren<Collider>())
            if (col.bounds.max.x > ret)
                ret = col.bounds.max.x;

        return ret;
    }
}
