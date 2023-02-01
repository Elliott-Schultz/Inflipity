using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool started = false;
    public TMPro.TMP_Text scoreText;
    private int score;
    private int highScore;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        scoreText.SetText(score.ToString());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(started)
        {
            time += Time.fixedDeltaTime;
            scoreText.SetText(score.ToString());
        }
    }

    public void StartTimer()
    {
        started = true;
    }

    public void EndTimer()
    {
        started = false;
    }

    public int getTime()
    {
        return (int)time;
    }
    public void incrementScore(int value) {
        score += value;
    }
    public int getScore() {
        return score;
    }
    public void setHighScore(int value) {
        highScore = value;
    }
    public int getHighScore() {
        return highScore;
    }
}
