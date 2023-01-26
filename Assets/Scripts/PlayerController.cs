using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canFlipGravity = true;

    public GameManager gameManager;
    private bool gameOver = true;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            if (Input.GetButtonDown("Jump") && canFlipGravity)
            {
                rb.gravityScale *= -1;
                canFlipGravity = false;
                sprite.flipY = !sprite.flipY;
                gameManager.IncreaseObstacleVelocity();

            }
            else if (Input.GetButtonUp("Jump"))
            {
                canFlipGravity = true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                Time.timeScale = 1;
                gameOver = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Die");
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
