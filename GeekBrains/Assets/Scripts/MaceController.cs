using UnityEngine;

public class MaceController : MonoBehaviour
{
    int pushForce;
    int damage;

    private void Start()
    {
        damage = 1;
        pushForce = 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Health -= damage;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * pushForce, ForceMode2D.Impulse);
        }
    }
}
