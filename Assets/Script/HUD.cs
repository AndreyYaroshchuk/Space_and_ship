using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private Image imageHealthPlayer_0;
    [SerializeField] private Image imageHealthPlayer_1;
    [SerializeField] private Image imageHealthPlayer_2;
   
    private void Update()
    {
        UpdateScore();
        HealthPlayerDamage();
        UpdateHealthPlayer();
    }
    private void UpdateScore()
    {
        textScore.text = GameManager.Instance.GetScore().ToString();
    }
    private void HealthPlayerDamage()
    {
        switch (Player.HealthPlayer)
        {
            case 0:
                imageHealthPlayer_0.gameObject.SetActive(false);
                break;
            case 1:
                imageHealthPlayer_1.gameObject.SetActive(false);
                break;
            case 2:
                imageHealthPlayer_2.gameObject.SetActive(false);
                break;
        }
    }
    private void UpdateHealthPlayer()
    {
        if (Player.HealthPlayer == 2)
            imageHealthPlayer_1.gameObject.SetActive(true);

        if (Player.HealthPlayer == 3)
            imageHealthPlayer_2.gameObject.SetActive(true);
    }
}
