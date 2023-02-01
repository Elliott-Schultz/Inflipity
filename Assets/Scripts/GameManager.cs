using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float obstacleVelocity;
    public float defaultVelocity = -5f;
    public float velocityDelta = 0.5f;
    public SegmentScript[] segments;
    public List<SegmentScript> easySegments;
    public List<SegmentScript> intermediateSegments;
    public List<SegmentScript> movingSegments;
    public List<SegmentScript> spinningSegments;
    public float powerUpScale = 1f;
    private Timer timeGetter;

    public SegmentScript getSegment() {
        // if (time.getTime() < 30) {
        //     return easySegments[Random.Range(0, easySegments.Count)];
        // } else if (time.getTime() >= 30 && time.getTime() < 60) {
        //     int rng = Random.Range(0, 8);
        //     if (rng < 2) {
        //         return easySegments[Random.Range(0, easySegments.Count)];
        //     } else if (rng >= 2 && rng < 6) {
        //         return intermediateSegments[Random.Range(0, intermediateSegments.Count)];
        //     } else if (rng == 6) {
        //         return movingSegments[Random.Range(0, movingSegments.Count)];
        //     } else {
        //         return spinningSegments[Random.Range(0, spinningSegments.Count)];
        //     }
        // } else if (time.getTime() >= 60 && time.getTime() < 120) {
        //     int rng = Random.Range(0, 8);
        //     if (rng < 2) {
        //         return easySegments[Random.Range(0, easySegments.Count)];
        //     } else if (rng >= 2 && rng < 4) {
        //         return intermediateSegments[Random.Range(0, intermediateSegments.Count)];
        //     } else if (rng >= 4 && rng < 6) {
        //         return movingSegments[Random.Range(0, movingSegments.Count)];
        //     } else {
        //         return spinningSegments[Random.Range(0, spinningSegments.Count)];
        //     }
        // } else {
        //     int rng = Random.Range(0, 8);
        //     if (rng < 2) {
        //         return intermediateSegments[Random.Range(0, intermediateSegments.Count)];
        //     } else if (rng >= 2 && rng < 5) {
        //         return movingSegments[Random.Range(0, movingSegments.Count)];
        //     } else {
        //         return spinningSegments[Random.Range(0, spinningSegments.Count)];
        //     }
        // }
        // Debug.Log(timeGetter.getTime());
        Debug.Log(easySegments.Count);
        return easySegments[Random.Range(0, easySegments.Count)];
    }

    // Start is called before the first frame update
    void Awake()
    {
        obstacleVelocity = defaultVelocity;
        segments = Resources.FindObjectsOfTypeAll<SegmentScript>();
        for (int i = 0; i < segments.Length; i++) {
            if (segments[i].name.ToLower().Contains("easy")) {
                easySegments.Add(segments[i]);
            } else if (segments[i].name.ToLower().Contains("intermediate")) {
                intermediateSegments.Add(segments[i]);
            } else if (segments[i].name.ToLower().Contains("moving")) {
                movingSegments.Add(segments[i]);
            } else if (segments[i].name.ToLower().Contains("spinning")) {
                spinningSegments.Add(segments[i]);
            }
        }
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
