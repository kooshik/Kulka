using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDispatcher : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameManager manager;
    public Animator anim;

    float speed = 0.8f;

    float timerCreate;
    float timerMove;

    int shift = 0;

    private void Start()
    {
        timerMove = Time.time;
        timerCreate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timerCreate + speed * 2)
        {
            timerCreate = Time.time;

            for (float n = -10; n < 10; n += 4f)
            {
                if (Random.value < 0.4)
                    Dispatch(n + shift * 2f);
            }

            shift = (shift + 1) % 2;
        }

        if (Time.time > timerMove + speed)
        {
            timerMove = Time.time;

            foreach (SpaceInvader invader in GetComponentsInChildren<SpaceInvader>())
                invader.transform.position = invader.transform.position + Vector3.down * 1.1f;
        }
    }

    private void Dispatch(float pos)
    {
        GameObject invader = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform, true);
        invader.transform.position = invader.transform.position + Vector3.left * pos;
        invader.GetComponent<SpaceInvader>().dispatcher = this;
        invader.SetActive(true);
    }

    public void Reset()
    {
        foreach (SpaceInvader invader in GetComponentsInChildren<SpaceInvader>())
            Destroy(invader.gameObject);
    }

    public void RestartLevel()
    {
        anim.Play("CamRedFlash");
        manager.RestartLevel();
    }
}
