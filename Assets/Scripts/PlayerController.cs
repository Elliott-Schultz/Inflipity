using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canFlipGravity = true;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && canFlipGravity)
        {
            rb.gravityScale *= -1;
            canFlipGravity = false;
            gameManager.IncreaseObstacleVelocity();
        }
        else if(Input.GetButtonUp("Jump"))
        {
            canFlipGravity = true;
        }
    }
}
