using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button buttonQuit;
    [SerializeField] Player player;
    private void Start()
    {
        Hide();
        player.OnGameOverPlayer += Player_OnGameOverPlayer;
        buttonQuit.onClick.AddListener(() =>
        {
            Hide();
            SceneManager.LoadScene(0);
        });
    }

    private void Player_OnGameOverPlayer(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
