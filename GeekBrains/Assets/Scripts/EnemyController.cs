using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int heath;

    private void Start()
    {
        heath = 2;
    }

    public int Health
    {
        get => heath;
        set
        {
            heath = value;
            if (heath <= 0) Death();
        }
    }

    public SpawnerController Spawner { get; set; }

    void Death()
    {
        Spawner.Spawn();
        Destroy(gameObject);
    }

}
