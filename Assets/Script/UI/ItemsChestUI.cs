using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ItemsChest { defolt, healthPlayer, speed, bullet, damage };
public class ItemsChestUI : MonoBehaviour
{
    public static ItemsChestUI Instance;
    [SerializeField] private Guns guns;
    [SerializeField] private TextMeshProUGUI textMaxHealthPlayer;
    [SerializeField] private TextMeshProUGUI textMaxGunsPlayer;
    [SerializeField] private Button buttonHealth;
    [SerializeField] private Button buttonSpeed;
    [SerializeField] private Button buttonDamage;
    [SerializeField] private Button buttonGuns;
    public static ItemsChest itemsChest;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Hide();
        textMaxHealthPlayer.gameObject.SetActive(false);
        textMaxGunsPlayer.gameObject.SetActive(false);
        buttonHealth.onClick.AddListener(() =>
        {
            if (Player.HealthPlayer < 3)
            {
                itemsChest = ItemsChest.healthPlayer;
                Hide();
            }
            else
            {
                textMaxHealthPlayer.gameObject.SetActive(true);
                Debug.Log("Максиум HP");  
            }
        });
        buttonSpeed.onClick.AddListener(() =>
        {
            itemsChest = ItemsChest.speed;
            
            Hide();
        });
        buttonDamage.onClick.AddListener(() =>
        {
            itemsChest = ItemsChest.damage;
            
            Hide();
        });
        buttonGuns.onClick.AddListener(() =>
        {
            if (!guns.GetMaxShowBulletSpawn()) {
                itemsChest = ItemsChest.bullet;
                Hide();
            }
            else
            {
                textMaxGunsPlayer.gameObject.SetActive(true);
            }
        });
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
