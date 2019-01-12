using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject Obj;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject temp = Instantiate(Obj, transform.position, Quaternion.identity);
        temp.GetComponent<EnemyController>().Spawner = this;
    }
}
