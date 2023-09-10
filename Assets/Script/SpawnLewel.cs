using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLewel : MonoBehaviour
{
    [SerializeField] List<LevelObjects> listGameObjectSpawn;
    [SerializeField] Chest spawnChest;
    [SerializeField] float speed = 1f;
   
    private void Start()
    {
        InvokeRepeating("MovetSpawn", 1f, 1f);
        InvokeRepeating("SpawnListGameObjectSpawn", 1f, 1f);
        InvokeRepeating("SpawnChest", Random.Range(10, 60), Random.Range(10, 60));
    }

    private void MovetSpawn()
    {
        int i = Random.Range(-110, 110);
        transform.position = new Vector3(i, transform.position.y, 90);
    }
    private void SpawnListGameObjectSpawn()
    {
        int i = Random.Range(0, listGameObjectSpawn.Count);
        Instantiate(listGameObjectSpawn[i], transform.position, Quaternion.identity); 
    }
    private void SpawnChest()
    {
        Instantiate(spawnChest, transform.position, Quaternion.identity);   
    }
}
