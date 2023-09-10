using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int maxHealthPlayer = -1;
    private int score;
    private void Awake()
    {
        Instance = this;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
}
