using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Chest : MonoBehaviour
{
    private const string TAG_STAR_SPARROW = "StarSparrow";
    private float speed = 3f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TAG_STAR_SPARROW)
        {

            ItemsChestUI.Instance.Show();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        UpdateItemsChest();
        Movet();
    }
    private void Movet()
    {
        transform.position += new Vector3(0, 0, -1f) * speed * Time.deltaTime  ;
    }
    private void UpdateItemsChest()
    {
        
        switch (ItemsChestUI.itemsChest)
        {
            case ItemsChest.healthPlayer:
                
                if (Player.HealthPlayer < 3)
                {
                    Player.HealthPlayer++;
                    ItemsChestUI.itemsChest = ItemsChest.defolt;
                }
                else
                {
                    Debug.Log("Максимум HP");
                }
                break;
            case ItemsChest.speed:
                Player.Speed++;
                Player.SpeedStart++;
                ItemsChestUI.itemsChest = ItemsChest.defolt;
                break;
            case ItemsChest.bullet:
                Guns.Instance.Show();
                ItemsChestUI.itemsChest = ItemsChest.defolt;
                break;
            case ItemsChest.damage:
                Bullet.Damage++;
                ItemsChestUI.itemsChest = ItemsChest.defolt;
                break;
        }
    }
}
