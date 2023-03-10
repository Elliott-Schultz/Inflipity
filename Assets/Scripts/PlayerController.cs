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
    public GameObject startScreen;
    public GameObject gameScreen;
    public GameObject endScreen;
    public AudioSource deathSound;
    public AudioSource gravityUp;
    public AudioSource gravityDown;
    public AudioSource running;
    public AudioSource helmet;
    private float distanceTraveled;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameScreen.SetActive(false);
        endScreen.SetActive(false);
        startScreen.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
        defaultGravity = rb.gravityScale;
        distanceTraveled = 0;
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
        else
        {
            if (started)
            {
                if (Input.GetButtonDown("Jump") && canFlipGravity)
                {
                    rb.gravityScale *= -1f;
                    defaultGravity *= -1f;
                    rb.velocity = new Vector2(0, rb.velocity.y / 2);
                    if (rb.gravityScale < 0f)
                    {
                        rb.gravityScale -= gravityIncreaseDelta;
                        gravityUp.PlayOneShot(gravityUp.clip, 1.0f);
                    }
                    else
                    {
                        rb.gravityScale += gravityIncreaseDelta;
                        gravityDown.PlayOneShot(gravityDown.clip, 1.0f);
                    }

                    canFlipGravity = false;
                    sprite.flipY = !sprite.flipY;
                    gameManager.IncreaseObstacleVelocity();

                }
                else if (Input.GetButtonUp("Jump"))
                {
                    canFlipGravity = true;
                }
                distanceTraveled += gameManager.getObstacleVelocity() * Time.deltaTime;
                timer.setScore(Mathf.RoundToInt(-1 * distanceTraveled));
                gameManager.setCurrentScore(timer.getScore());
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Time.timeScale = 1;
                    running.Play();
                    helmet.Play();
                    started = true;
                    timer.StartTimer();
                    gameScreen.SetActive(true);
                    startScreen.SetActive(false);
                }
            }
        }
    }

    public void Die()
    {
        Debug.Log("Die");
        if (timer.getScore() > timer.getHighScore())
        {
            timer.setHighScore(timer.getScore());
            PlayerPrefs.SetInt("highScore", timer.getHighScore());
            PlayerPrefs.Save();
        }
        Debug.Log("High Score: " + PlayerPrefs.GetInt("highScore"));
        scoreText.text += timer.getScore();
        highScoreText.text += timer.getHighScore();
        timer.EndTimer();
        Time.timeScale = 0;
        started = false;
        died = true;
        StartCoroutine(waitForSound());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PowerUp")
        {
            Debug.Log("Slow Down");
            int timeDiff = Mathf.Min(timer.getTime() - previousPowerUpTime, 15);
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
            distanceTraveled -= 100;
        }
    }
    IEnumerator waitForSound() {
        deathSound.PlayOneShot(deathSound.clip, 1.0f);
        yield return new WaitWhile(() => deathSound.isPlaying);
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
    }
}
