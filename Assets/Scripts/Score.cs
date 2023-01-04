using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameManager game;
    public TextMesh text;
    public string postfix;

    private int score;

    public void ScoreIncrease(int delta)
    {
        score += delta;
        text.text = score.ToString() + postfix;
    }

    public void Reset()
    {
        score = 0;
        text.text = score.ToString() + postfix;
    }

    public void AdvanceLevel(int threshold)
    {
        if (score >= threshold)
            game.LevelUp();
    }
}
