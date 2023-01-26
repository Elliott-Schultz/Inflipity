using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool started = false;
    public TMPro.TMP_Text scoreText;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        scoreText.SetText(Math.Round(time, 2).ToString("0.00"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(started)
        {
            time += Time.fixedDeltaTime;
            scoreText.SetText(Math.Round(time, 2).ToString("0.00"));
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
}
