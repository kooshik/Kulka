using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeSelection : MonoBehaviour
{
    public Camera cam;
    public Ball ball;
    public MeshRenderer[] paintingsOff;
    public MeshRenderer[] paintingsOn;

    private int sceneIndex = -1;

    private void Start()
    {
        ball.onJump += Ball_onJump;
    }

    private void Ball_onJump()
    {
        // find the nearest art        
        float dist = float.MaxValue; //Mathf.Abs(ball.transform.position.x - scene[0].transform.position.x);

        for (int n = 0; n < paintingsOff.Length; n++)
        {
            float distNew = Mathf.Abs(cam.WorldToViewportPoint(ball.transform.position).x - cam.WorldToViewportPoint(paintingsOff[n].transform.position).x);

            if (distNew < dist && distNew < 0.06f)
            {
                sceneIndex = n;
                dist = distNew;
            }
        }

        SelectScene(sceneIndex);
    }

    public void SelectScene(int sceneIndex)
    {
        this.sceneIndex = sceneIndex;

        for (int n = 0; n < paintingsOff.Length; n++)
        {
            paintingsOn[n].gameObject.SetActive(n == sceneIndex);
            paintingsOff[n].gameObject.SetActive(n != sceneIndex);
        }
    }

    public void ApplyScene()
    {
        if (sceneIndex >= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex + 1);
    }
}
