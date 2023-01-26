using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (-speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
