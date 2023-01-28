using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float obstacleVelocity;
    public float defaultVelocity = -5f;
    public float velocityDelta = 0.5f;
    public Segment[] segments;
    public float powerUpScale = 1f;

    public Segment getSegment() {
        return segments[Random.Range(0, segments.Length)];
    }

    // Start is called before the first frame update
    void Start()
    {
        obstacleVelocity = defaultVelocity;
        segments = Resources.FindObjectsOfTypeAll<Segment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getObstacleVelocity() {
        return obstacleVelocity;
    }

    public float getVelocityDelta() {
        return velocityDelta;
    }

    public void IncreaseObstacleVelocity()
    {
        obstacleVelocity -= velocityDelta;
    }

    public void DecreaseObstacleVelocity(int timeDiff)
    {
        Debug.Log(obstacleVelocity);
        obstacleVelocity += (velocityDelta * timeDiff * powerUpScale);
        obstacleVelocity = Mathf.Min(defaultVelocity, obstacleVelocity);
        Debug.Log(obstacleVelocity);
    }
}
