using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float obstacleVelocity;
    public float defaultVelocity = -5f;
    public float velocityDelta = 0.5f;
    public List<SegmentScript> easySegments;
    public List<SegmentScript> mediumSegments;
    public List<SegmentScript> movingSegments;
    public List<SegmentScript> spinningSegments;
    public float powerUpScale = 1f;
    private int currentScore = 0;

    public float fixedDeltaTime = .001f;
    

    public SegmentScript getSegment() {
        if (currentScore < 250) {
            return easySegments[Random.Range(0, easySegments.Count)];
        } else if (currentScore >= 250 && currentScore < 1000) {
            int rng = Random.Range(0, 8);
            if (rng < 2) {
                return easySegments[Random.Range(0, easySegments.Count)];
            } else if (rng >= 2 && rng < 6) {
                return mediumSegments[Random.Range(0, mediumSegments.Count)];
            } else if (rng == 6) {
                return movingSegments[Random.Range(0, movingSegments.Count)];
            } else {
                return spinningSegments[Random.Range(0, spinningSegments.Count)];
            }
        } else if (currentScore >= 1000 && currentScore < 4000) {
            int rng = Random.Range(0, 8);
            if (rng < 2) {
                return easySegments[Random.Range(0, easySegments.Count)];
            } else if (rng >= 2 && rng < 4) {
                return mediumSegments[Random.Range(0, mediumSegments.Count)];
            } else if (rng >= 4 && rng < 6) {
                return movingSegments[Random.Range(0, movingSegments.Count)];
            } else {
                return spinningSegments[Random.Range(0, spinningSegments.Count)];
            }
        } else {
            int rng = Random.Range(0, 8);
            if (rng < 2) {
                return mediumSegments[Random.Range(0, mediumSegments.Count)];
            } else if (rng >= 2 && rng < 5) {
                return movingSegments[Random.Range(0, movingSegments.Count)];
            } else {
                return spinningSegments[Random.Range(0, spinningSegments.Count)];
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Time.fixedDeltaTime = fixedDeltaTime;
        obstacleVelocity = defaultVelocity;
        Application.targetFrameRate = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            Application.Quit();
        }
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
    public void setCurrentScore(int value) {
        currentScore = value;
    }
}
