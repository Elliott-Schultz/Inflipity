using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public GameManager manager;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake() {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(manager.getObstacleVelocity(), 0);
        if (transform.position.x < -15 && !spawned) {
            Instantiate(manager.getSegment(), new Vector3(transform.position.x + 50, 0, 0), transform.rotation);
            spawned = true;
        }
        if (transform.position.x < -35 && spawned) {
            Destroy(gameObject);
            spawned = false;
        }
    }
}
