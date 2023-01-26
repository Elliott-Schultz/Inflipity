using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float obstacleVelocity = -5f;
    public float velocityDelta = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseObstacleVelocity()
    {
        obstacleVelocity -= velocityDelta;
    }
}
