using UnityEngine;

public class Coin : MonoBehaviour
{
    public LayerMask GroundLayer;
    Rigidbody2D rigidbody2d;
    Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsGrounded())
        {
            rigidbody2d.simulated = false;
            animator.SetBool("ground", true);
            enabled = false;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, GroundLayer);
        if (hit.collider)
            return true;            
        return false;
    }

}
