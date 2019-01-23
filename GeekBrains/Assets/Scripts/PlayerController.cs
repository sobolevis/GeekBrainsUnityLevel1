using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public GameObject Bullet;
    public LayerMask GroundLayer;

    int health = 5;
    bool right = true;
    float horizontal;
    Rigidbody2D rb;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0) Death();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal"))        
            Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))        
            Shoot();

        if (Input.GetButtonDown("Vertical") && IsGrounded())        
            Jump();
    }

    void Move()
    {
        if (horizontal > 0 && !right) Flip();
        else if (horizontal < 0 && right) Flip();
        Vector3 direction = Vector3.right * horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    void Shoot()
    {
        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.identity);
        if (right) temp.GetComponent<BulletController>().Direction = 1;
        else temp.GetComponent<BulletController>().Direction = -1;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, GroundLayer);
        if (hit.collider != null)
            return true;
        return false;
    }

    void Death()
    {
        SceneManager.LoadScene("MainScene");
    }

}
