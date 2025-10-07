using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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


    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool jumped = false;
    private float noMouseTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        winUI.SetActive(false);
        noMouseUI.SetActive(false);
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        SetAnimation(moveInput);
        healthImage.fillAmount = health / 100f;
    }

    private void FixedUpdate()
    {
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
            jumped = false;
        }
    }

    private void SetAnimation(float moveInput)
    {
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
        if (collision.gameObject.tag == "Damage")
        {
            Debug.Log("Damage tag");
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            StartCoroutine(BlinkRed());

            if (health <= 0)
            {
                Die();
            }
        }
        if (collision.gameObject.tag == "InstaDeath")
        {
            Debug.Log("Instadeath tag");
            Die();
        }
        if (collision.gameObject.tag == "Mitten")
        {
            Debug.Log("Mitten tag");
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
        yield return new WaitForSeconds(noMouseTime); // Wait for 'delay' seconds
        gameObject.SetActive(false); // Deactivate the object
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1_Scene");
    }
}
