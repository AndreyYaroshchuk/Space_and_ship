using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button buttonStart;
    [SerializeField] Button buttonQuit;
    [SerializeField] GameObject instruction;

    private void Start()
    {
        instruction.gameObject.SetActive(false);
        buttonStart.onClick.AddListener(() =>
        {
            instruction.gameObject.SetActive(true);
            Invoke("LoadScene", 5f);
        });
        buttonQuit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(1);
        instruction.gameObject.SetActive(false);
    }
}
