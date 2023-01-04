using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Rigidbody Ball;
    public Level[] levels;
    public int currLevel = 0;
    public Transform StartWall;
    public Transform EndWall;
    public Vector3 LeftWallPosition;
    public Vector3 RightWallPosition;

    private void Start()
    {
        for (int n = 0; n < levels.Length; n++)
            levels[n].gameObject.SetActive(false);

        RestartLevel();
    }

    public void LevelUp()
    {
        // make sure currLevel corresponds to active one
        for (int n = 0; n < levels.Length; n++)
            if (levels[n].gameObject.activeSelf)
                currLevel = n;

        levels[currLevel].gameObject.SetActive(false);

        if (currLevel + 1 < levels.Length) // ball        
            currLevel++;

        Ball.velocity = Vector3.zero;
        Ball.angularVelocity = Vector3.zero;
        Ball.transform.position = levels[currLevel].BallEnterPoint.position;
        Ball.GetComponent<Ball>().isActive = false;
        Ball.GetComponent<Ball>().Reset();
        SetWallsPositions(levels[currLevel].endPosition);

        levels[currLevel].gameObject.SetActive(true);
        levels[currLevel].Save();
    }

    public void RestartLevel()
    {
        Ball.velocity = Vector3.zero;
        Ball.angularVelocity = Vector3.zero;
        Ball.transform.position = levels[currLevel].BallEnterPoint.position;
        Ball.GetComponent<Ball>().isActive = false;
        Ball.GetComponent<Ball>().Reset();
        SetWallsPositions(levels[currLevel].endPosition);

        levels[currLevel].gameObject.SetActive(true);
        levels[currLevel].Load();
    }

    private void SetWallsPositions(WallPosition endWallPosition)
    {
        if (endWallPosition == WallPosition.left)
        {
            EndWall.position = LeftWallPosition;
            StartWall.position = RightWallPosition;
        }
        else
        {
            StartWall.position = LeftWallPosition;
            EndWall.position = RightWallPosition;
        }
    }

    public void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
