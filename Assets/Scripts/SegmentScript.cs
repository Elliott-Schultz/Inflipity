using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public GameManager manager;
    [SerializeField] private bool spawned = false;
    [SerializeField] private float left;
    [SerializeField] private float right;

    public bool isStart = false;
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
        float pos = transform.position.x;
        if (!isStart)
        {
            if (pos < right - 15 && !spawned)
            {
                SegmentScript seg = Instantiate(manager.getSegment(), new Vector3(pos + 50, 0, 0), transform.rotation);
                seg.GetComponent<Rigidbody2D>().velocity = new Vector2(manager.getObstacleVelocity(), 0);
                spawned = true;
            }
        }
        else
        {
            if(!spawned)
            {
                SegmentScript seg = Instantiate(manager.getSegment(), new Vector3(pos + 50, 0, 0), transform.rotation);
                seg.GetComponent<Rigidbody2D>().velocity = new Vector2(manager.getObstacleVelocity(), 0);
                spawned = true;
            }
        }

        if (pos < left - 35 && spawned)
        {
            Destroy(gameObject);
            spawned = false;
        }
    }
}
