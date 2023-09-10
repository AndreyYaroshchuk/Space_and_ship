using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelObjects : MonoBehaviour
{
    public static event EventHandler OnDamagePlayer;
    private const string TAG_STAR_SPARROW = "StarSparrow";
    private static float hp = 5f;
    private float speed;
    private float damagePlayer = 1f;
    private Rigidbody rb;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Bullet_OnBulletDamaged(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        hp = 3f;
        speed = 20f;
    }
    private void Update()
    {
        MovetSpawnGameObject();
      
    }
    private void MovetSpawnGameObject()
    {
        transform.localPosition += Vector3.back * speed * Time.deltaTime;
        rb.AddTorque(0f, 1f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TAG_STAR_SPARROW)
        {
            Destroy(gameObject);
            OnDamagePlayer?.Invoke(this, EventArgs.Empty);
            Player.HealthPlayer -= damagePlayer;    
        }
    }

    private void Dies()
    { 
        if (hp <= 0)
        {
            int score = GameManager.Instance.GetScore();
            score++;
            GameManager.Instance.SetScore(score);
            Destroy(gameObject);
        }
    }
    public void DamageLevelObject(float damage)
    {
        Dies();
        animator.SetTrigger("Hit");
        hp -= damage;   
    }
}
