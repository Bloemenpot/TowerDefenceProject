using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 200;

    public static int Lives;
    public int startLives = 20;

    public static int Kills;
    public int startKills = 0;

    public static int Round = 0;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Kills = startKills;
    }
}