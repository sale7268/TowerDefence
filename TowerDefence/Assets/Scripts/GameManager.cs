﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Score UI")]
    public GameObject EnemyHealthText;
    public GameObject CoinText;

    public int EnemyHealth = 100;
    public int CoinCount = 0;

    public void EnemyHit()
    {
        EnemyHealth -= 20;
        EnemyHealthText.GetComponent<TMPro.TextMeshProUGUI>().text = EnemyHealth.ToString();
        EnemyHealthText.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Debug.Log("Ouch!");

        CoinCount += 10;
        CoinText.GetComponent<TMPro.TextMeshProUGUI>().text = CoinCount.ToString();
    }
}