using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : MonoBehaviour
{
    public Transform spawnPoint;
    public Trigger spawnCheck;
    public GameObject[] blockPrefab;
    public GameObject plan;

    public TetrisPiece currentBlock;
    private float timerDown;
    private float timerSide;
    private float timerNewBlock;

    void FixedUpdate()
    {
        if (currentBlock != null && !currentBlock.gravity && Time.time > timerDown + 0.8f)
        {
            timerDown = Time.time;
            currentBlock.transform.position = currentBlock.transform.position + Vector3.down;
        }
    }

    void OnTriggerStay(Collider other)
    {
        plan.SetActive(true);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            if (currentBlock != null && !currentBlock.gravity)
            {
                timerNewBlock = Time.time - 2;
                currentBlock.Drop();
            }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            if (currentBlock != null && !currentBlock.gravity && Time.time > timerSide + 0.1f)
            {
                timerSide = Time.time;
                currentBlock.Turn();
            }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            if (currentBlock != null && !currentBlock.gravity && Time.time > timerSide + 0.1f && currentBlock.GetLeftSqrPos() > -3)
            {
                timerSide = Time.time;
                currentBlock.transform.position = currentBlock.transform.position + Vector3.left;
            }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            if (currentBlock != null && !currentBlock.gravity && Time.time > timerSide + 0.1f && currentBlock.GetRightSqrPos() < 10)
            {
                timerSide = Time.time;
                currentBlock.transform.position = currentBlock.transform.position + Vector3.right;
            }

        if (currentBlock == null)
            NewBlock();
    }

    public void NewBlock()
    {
        if (Time.time > timerNewBlock + 2.4f)
        {
            timerNewBlock = Time.time;
            GameObject newBlock = Instantiate(blockPrefab[Random.Range(0, blockPrefab.Length)], spawnPoint, true);

            Color col = new Color(Random.value / 4, Random.value / 4, Random.value / 4);
            for (int n = 0; n < newBlock.transform.childCount; n++)
                newBlock.transform.GetChild(n).GetComponent<MeshRenderer>().material.color = col;

            newBlock.SetActive(true);

            if (currentBlock != null)
                currentBlock.Drop();

            currentBlock = newBlock.GetComponent<TetrisPiece>();
            currentBlock.controller = this;
            timerDown = Time.time;
        }
    }

    public void ClearBlocks()
    {
        for (int n = 0; n < spawnPoint.childCount; n++)
            Destroy(spawnPoint.GetChild(n).gameObject);
    }
}
