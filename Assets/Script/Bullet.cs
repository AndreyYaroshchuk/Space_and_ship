using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Bullet : MonoBehaviour
{
    private const string TAG_LEVEOBJECT = "LevelObject";
    private static float damage = 5f;
    [SerializeField] private float speed = 100f;

    public static float Damage { get => damage; set => damage = value; }

    private void Update()
    {
        MovetBullet();
    }

    private void MovetBullet()
    {
        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == TAG_LEVEOBJECT)
    //    {
    //        Debug.Log("урон мобу");
    //        LevelObjects.Hp -= damage;
    //        Destroy(gameObject);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        LevelObjects levelObjects = collision.gameObject.GetComponent<LevelObjects>();
        if (levelObjects != null)
        {
            levelObjects.DamageLevelObject(Damage);
            Destroy(gameObject); 
        }
    }
}
