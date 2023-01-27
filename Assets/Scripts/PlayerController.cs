using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canFlipGravity = true;
    private float defaultGravity;
    public float gravityIncreaseDelta = 0.05f;

    public GameManager gameManager;
    private bool started = false;
    private bool died = false;

    public SpriteRenderer sprite;

    public Timer timer;
    private int previousPowerUpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
        defaultGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(died)
        {
            if(Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(started)
        {
            if (Input.GetButtonDown("Jump") && canFlipGravity)
            {
                rb.gravityScale *= -1f;
                defaultGravity *= -1f;
                if(rb.gravityScale < 0f)
                {
                    rb.gravityScale -= gravityIncreaseDelta;
                }
                else
                {
                    rb.gravityScale += gravityIncreaseDelta;
                }

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
                started = true;
                timer.StartTimer();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Die");
            timer.EndTimer();
            Time.timeScale = 0;
            started = false;
            died = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PowerUp")
        {
            Debug.Log("Slow Down");
            int timeDiff = timer.getTime() - previousPowerUpTime;
            if(rb.gravityScale > 0f)
            {
                rb.gravityScale -= timeDiff * gravityIncreaseDelta;
                rb.gravityScale = Mathf.Max(rb.gravityScale, defaultGravity);
            }
            else
            {
                rb.gravityScale += timeDiff * gravityIncreaseDelta;
                rb.gravityScale = Mathf.Min(rb.gravityScale, defaultGravity);
            }
            gameManager.DecreaseObstacleVelocity(timeDiff);
            Destroy(collision.gameObject);
        }
    }
}
