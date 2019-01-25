using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Obj;
    GameObject currentEnemy;
    WaitForSeconds delaySpawn = new WaitForSeconds(3f);    
    bool spawned = false;

    private void Update()
    {
        if (currentEnemy == null && !spawned)
        {
            spawned = !spawned;
            Spawn();
        }        
    }

    public void Spawn()
    {
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        yield return delaySpawn;
        currentEnemy = Instantiate(Obj, transform.position, Quaternion.identity);
        spawned = !spawned;
    }

}
