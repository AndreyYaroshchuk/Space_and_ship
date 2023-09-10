using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public static Guns Instance;
    [SerializeField] private List<GameObject> bulletSpawn;
    private int countSetActivebulletSpawn = 1;
    private void Awake()
    {
        Instance = this;
    }
    public void Show()
    {
        bulletSpawn[countSetActivebulletSpawn].SetActive(true);
        countSetActivebulletSpawn++;
    }
    public bool GetMaxShowBulletSpawn()
    {
        if(countSetActivebulletSpawn == bulletSpawn.Count)
        {
            return true;
        }
        return false;
    }


}
