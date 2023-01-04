using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public Color camColor = Color.white;
    public Transform BallEnterPoint;
    public WallPosition endPosition;

    public Transform[] objectsToRemember;

    public UnityEvent OnLoad;

    private Vector3[] objectPos;
    private Quaternion[] objectRot;
    private Color[] objectCol;
    private bool[] killPlayerActive;

    private void Start()
    {
        Save();
    }

    private void Init()
    {
        objectPos = new Vector3[objectsToRemember.Length];
        objectRot = new Quaternion[objectsToRemember.Length];
        objectCol = new Color[objectsToRemember.Length];
        killPlayerActive = new bool[objectsToRemember.Length];
        Camera.main.backgroundColor = camColor;
    }

    public void Save()
    {
        if (objectPos == null)
            Init();

        for (int n = 0; n < objectsToRemember.Length; n++)
        {
            objectPos[n] = objectsToRemember[n].position;
            objectRot[n] = objectsToRemember[n].rotation;

            MeshRenderer mesh = objectsToRemember[n].GetComponent<MeshRenderer>();

            if (mesh != null)
                objectCol[n] = mesh.material.color;

            KillPlayerOnTouch killer = objectsToRemember[n].GetComponent<KillPlayerOnTouch>();

            if (killer != null)
                killPlayerActive[n] = killer.isActive;
        }
    }

    public void Load()
    {
        if (OnLoad != null)
            OnLoad.Invoke();

        if (objectPos != null)
            for (int n = 0; n < objectsToRemember.Length; n++)
            {
                objectsToRemember[n].SetPositionAndRotation(objectPos[n], objectRot[n]);

                Rigidbody rig = objectsToRemember[n].GetComponent<Rigidbody>();

                if (rig != null)
                {
                    rig.velocity = Vector3.zero;
                    rig.angularVelocity = Vector3.zero;
                }

                MeshRenderer mesh = objectsToRemember[n].GetComponent<MeshRenderer>();

                if (mesh != null && mesh.material != null)
                    mesh.material.color = objectCol[n];

                KillPlayerOnTouch killer = objectsToRemember[n].GetComponent<KillPlayerOnTouch>();

                if (killer != null)
                    killer.isActive = killPlayerActive[n];
            }
    }
}
