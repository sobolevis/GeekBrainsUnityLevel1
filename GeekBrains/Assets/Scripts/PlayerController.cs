using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool right = true;
    bool onGround = true;
    public float jumpPower;
    public float speed;
    float horizontal;
    Vector3 direction;
    Rigidbody2D rb;
    public GameObject bullet;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shoot");
            Shoot();
        }

        if (Input.GetButton("Vertical") && onGround)
        {
            Jump();
        }

    }

    void Move()
    {
        if (horizontal > 0 && !right) Flip();
        else if (horizontal < 0 && right) Flip();
        direction = Vector3.right * horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Jump()
    {
        onGround = false;
        Vector2 temp = Vector2.up;
        rb.velocity += temp * jumpPower;
    }

    void Shoot()
    {
        GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }

}
