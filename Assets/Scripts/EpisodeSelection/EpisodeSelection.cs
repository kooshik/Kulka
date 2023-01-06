using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeSelection : MonoBehaviour
{
    public EpisodeTile[] episodeTiles;

    private int sceneIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            episodeTiles[sceneIndex].Select(false);

            sceneIndex--;
            sceneIndex %= episodeTiles.Length;

            episodeTiles[sceneIndex].Select(true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            episodeTiles[sceneIndex].Select(false);

            sceneIndex++;
            sceneIndex %= episodeTiles.Length;

            episodeTiles[sceneIndex].Select(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            ApplyScene();
        }
    }

    public void ApplyScene()
    {
        if (sceneIndex >= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex + 1);
    }
}
