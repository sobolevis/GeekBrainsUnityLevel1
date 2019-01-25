using UnityEngine;

public class Mace : MonoBehaviour
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
            collision.gameObject.GetComponent<Player>().Health -= damage;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position).normalized * pushForce, ForceMode2D.Impulse);
        }
    }
}
