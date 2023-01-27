using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float obstacleVelocity;
    public float defaultVelocity = -5f;
    public float velocityDelta = 0.5f;
    public List<GameObject> segments;
    public float powerUpScale = 1f;
    private int previousPowerUpTime = 0;
    public GameObject getSegment() {
        return segments[Random.Range(0, segments.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        obstacleVelocity = defaultVelocity;
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

    public void DecreaseObstacleVelocity(int powerUpTime)
    {
        Debug.Log(obstacleVelocity);
        int timeDiff = powerUpTime - previousPowerUpTime;
        obstacleVelocity += (velocityDelta * timeDiff * powerUpScale);
        obstacleVelocity = Mathf.Min(defaultVelocity, obstacleVelocity);
        Debug.Log(obstacleVelocity);
        previousPowerUpTime = powerUpTime;
    }
}
