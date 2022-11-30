using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumber : MonoBehaviour
{
    public Text roundText;
    void Update()
    {
        roundText.text = PlayerStats.Round.ToString();
    }
}
