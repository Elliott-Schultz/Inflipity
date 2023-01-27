using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float obstacleVelocity = -5f;
    public float velocityDelta = 0.5f;
    public List<GameObject> segments;
    public GameObject getSegment() {
        return segments[Random.Range(0, segments.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
