using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int mouse;
    public int health = 100;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Image healthImage;
    public GameObject winUI;
    public ParticleSystem landParticles;
    public GameObject noMouseUI;
    public AudioSource landSound;


    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool jumped = false;
    private float noMouseTime = 3f;

    void Start()
    {
        // create all variables
        // set some UIs to be inactive
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        winUI.SetActive(false);
        noMouseUI.SetActive(false);

    }

    void Update()
    {
        // get current input on horizontal axis, add movement to player based on number
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        // jump by adding upward force to player
        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // animate and update health bar
        SetAnimation(moveInput);
        healthImage.fillAmount = health / 100f;
    }

    private void FixedUpdate()
    {
        // flip player sprite if moving left or right, if landing after jump then trigger small snow poof
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (isGrounded && jumped)
        {
            landParticles.Play();
            landSound.PlayOneShot(landSound.clip);;
            jumped = false;
        }
    }

    private void SetAnimation(float moveInput)
    {
        // if grounded and not moving then idle, if moving then play walk
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Walk");
            }
        }
        else
        {
            //if moving up play jump, if moving down play fall
            if (rb.linearVelocityY > 0)
            {
                animator.Play("Player_Jump");
            }
            else
            {
                animator.Play("Player_Fall");
                jumped = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if colision with damage decrease health, flash red, jump
        if (collision.gameObject.tag == "Damage")
        {
            Debug.Log("Damage tag");
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            StartCoroutine(BlinkRed());

            // if health too low die
            if (health <= 0)
            {
                Die();
            }
        }
        // if collision with instedeath, die
        if (collision.gameObject.tag == "InstaDeath")
        {
            Die();
        }

        //if collide with mitten and have mouse, open menu
        // no mouse means pop up ui message
        if (collision.gameObject.tag == "Mitten")
        {
            if (mouse == 1)
            {
                Time.timeScale = 0;
                winUI.SetActive(true);
            }
            else
            {
                noMouseUI.SetActive(true);
                StartCoroutine(DeactivateObject(noMouseUI));

            }
        }
    }

    private IEnumerator DeactivateObject(GameObject gameObject)
    {
        // wait then destroy object
        yield return new WaitForSeconds(noMouseTime);
        gameObject.SetActive(false);
    }

    private IEnumerator BlinkRed()
    {
        //set bear red for time, then back to white
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        // restarts the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1_Scene");
    }
}
