using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") SceneManager.LoadScene("MainScene");
        else Destroy(collision.gameObject);
    }
}
