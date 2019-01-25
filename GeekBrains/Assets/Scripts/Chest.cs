using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject Coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < 3; i++)
            {                
                GameObject obj = Instantiate(Coin, transform.position + Vector3.up, transform.rotation);
                obj.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(Random.Range(-1, 1), 3), ForceMode2D.Impulse);
            }
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Animator>()?.SetBool("open", true);
            enabled = false;
        }
    }

}
