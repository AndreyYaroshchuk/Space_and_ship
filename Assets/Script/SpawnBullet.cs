using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    
    private GameObject bullet;
    [SerializeField] private GameObject prefabsBullet;
    

    private void Start()
    {
        InvokeRepeating("SpawnBullets", 0.5f, 0.5f);
    }
    private void SpawnBullets()
    {
        bullet = Instantiate(prefabsBullet, transform.position, Quaternion.identity);
        Destroy(bullet, 2f);
    }
}
