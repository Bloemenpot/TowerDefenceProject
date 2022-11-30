using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public Text moneyText;

    void FixedUpdate()
    {
        moneyText.text = "♦" + PlayerStats.Money.ToString();
    }
}
