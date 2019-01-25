using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Direction;
    public float Speed;
    public int Damage;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * Direction * Speed, ForceMode2D.Impulse);
    }

    /*private void Update()
    {
        Move();
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        var temp = other.gameObject.GetComponent<Enemy>();
        if (temp != null)
        {
            temp.Health -= Damage;
            Destroy(gameObject);
        }        
    }

    void Move()
    {        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(Direction, 0, 0), Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
