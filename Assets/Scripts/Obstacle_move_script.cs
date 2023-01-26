using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_move_script : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public float maxHeight;

    public float minHeight;

    private bool moveUp = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rb.position.y >= maxHeight) {
            moveUp = false;
        } else if(rb.position.y <= minHeight) {
            moveUp = true;
        }
        
        if(moveUp) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }
}
