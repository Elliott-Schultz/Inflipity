using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public GameManager manager;
    private bool spawned = false;
    private float left;
    private float right;
    // Start is called before the first frame update
    void Start()
    {
        left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }
    void Awake() {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(manager.getObstacleVelocity(), 0);
        if (transform.position.x < right - 15 && !spawned) {
            Instantiate(manager.getSegment(), new Vector3(transform.position.x + 50, 0, 0), transform.rotation);
            spawned = true;
        }
        if (transform.position.x < left - 35 && spawned) {
            Destroy(gameObject);
            spawned = false;
        }
    }
}
