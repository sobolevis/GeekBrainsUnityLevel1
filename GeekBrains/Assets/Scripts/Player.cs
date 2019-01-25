using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public GameObject Bullet;
    public LayerMask GroundLayer;
    public AudioClip[] AudioClips;

    int health = 5;
    bool right = true;
    float horizontal;
    Rigidbody2D rigidbody2d;
    Animator animator;
    AudioSource audioSource;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0)
                Death();
        }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Animation();            
    }

    void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal"))
            Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();

        if (Input.GetButtonDown("Vertical") && IsGrounded())
            Jump();
    }

    void Animation()
    {
        if (IsGrounded())
        {
            if (rigidbody2d.velocity.y == 0)
            {
                animator.SetBool("jumpUp", false);
                animator.SetBool("jumpDown", false);
                animator.SetBool("idle", true);
            }

            if (Mathf.Abs(horizontal) > 0 && rigidbody2d.velocity.y == 0)
            {
                animator.SetBool("run", true);
            }
            else
                animator.SetBool("run", false);
            
        } else
        {
            if (rigidbody2d.velocity.y > 0.2)
                animator.SetBool("jumpUp", true);
            else
                animator.SetBool("jumpDown", true);
        }
    }

    void Move()
    {
        if (horizontal > 0 && !right) Flip();
        else if (horizontal < 0 && right) Flip();
        Vector3 direction = Vector3.right * horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime);

        if (!audioSource.isPlaying && IsGrounded())
        {
            audioSource.clip = AudioClips[Random.Range(0, 2)];
            audioSource.Play();
        }        
    }

    void Jump()
    {
        rigidbody2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        audioSource.clip = AudioClips[2];
        audioSource.Play();
    }

    void Shoot()
    {
        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.identity);
        if (right) temp.GetComponent<Bullet>().Direction = 1;
        else temp.GetComponent<Bullet>().Direction = -1;
    }

    void Flip()
    {
        right = !right;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }    

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, GroundLayer);
        if (hit.collider)
            return true;
        return false;
    }

    void Death()
    {
        SceneManager.LoadScene("MainScene");
    }

}
