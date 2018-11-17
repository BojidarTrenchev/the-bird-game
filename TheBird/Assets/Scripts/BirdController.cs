using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BirdController : MonoBehaviour
{
    public float jumpSpeed = 2;
    public float forwardSpeed = 5;
    public float maxVelocityX = 3;
    public AudioClip explosionSound;
    public AudioClip flapSound;
    public AudioClip backgroundMusic;
    public AudioClip passSound;
    public static bool isDead;
    public bool isMoved;

    private MenuManager menu;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject explosion;
    private AudioSource audioSorce;

    public bool didFlap;
    private bool gameStarted;
    private float jumpSpeedSave;
    private float forwardSpeedSave;

    // Use this for initialization
    public void Start()
    {
        this.menu = GameObject.Find("MainCanvas").GetComponent<MenuManager>();
        this.audioSorce = this.GetComponent<AudioSource>();
        this.explosion = GameObject.Find("Explosion");
        this.rb = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();

        AudioSource.PlayClipAtPoint(this.backgroundMusic, this.transform.position, 0.1f);
        this.explosion.SetActive(false);
        this.forwardSpeedSave = this.forwardSpeed;
        this.jumpSpeedSave = this.jumpSpeed;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isDead)
        {
            if (!this.menu.panel.activeSelf)
            {
                didFlap = true;
                this.isMoved = true;
                this.audioSorce.PlayOneShot(this.flapSound, 0.5f);
            }
            this.gameStarted = true;

        }
        else if(isDead)
        {
            this.anim.SetBool("Dead", true);
            ScoreManager.SaveScore();
        }
    }

    public void FixedUpdate()
    {
        if (!gameStarted)
        {
            this.StarStopGame(true,true);
        }
        else
        {
            this.StarStopGame(false,false);

        }
        if (!isDead)
        {
            if (didFlap)
            {
                didFlap = false;
                this.rb.AddForce(new Vector2(0, this.jumpSpeed));
            }
            var currenVelocity = this.rb.velocity;
            currenVelocity.x = forwardSpeed;
            this.rb.velocity = currenVelocity;
        }
        else
        {
            this.StarStopGame(false, false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            this.explosion.SetActive(true);
            this.audioSorce.PlayOneShot(this.explosionSound);
            isDead = true;
            this.isMoved = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("TreeTrigger"))
        {
            ScoreManager.score++;
            this.audioSorce.PlayOneShot(this.passSound, 0.4f);
        }
    }

    public void StarStopGame(bool setSpeedsToZero, bool isKinematic)
    {
        if (!setSpeedsToZero)
        {
            this.forwardSpeed = this.forwardSpeedSave;
            this.jumpSpeed = this.jumpSpeedSave;
        }
        else
        {
            this.forwardSpeed = 0;
            this.jumpSpeed = 0;
        }

        if (isKinematic)
        {
            this.rb.isKinematic = true;
        }
        else
        {
            this.rb.isKinematic = false;
        }

    }
}
