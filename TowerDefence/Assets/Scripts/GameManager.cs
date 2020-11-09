using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Score UI")]
    public GameObject EnemyHealthText;
    public GameObject TowerHealthText;
    public GameObject CoinText;
    public GameObject ResButton;

    public int EnemyHealth = 100;
    public int TowerHealth = 100;
    public int CoinCount = 0;

    public Image healthBar;

    public void Update()
    {
        if(EnemyHealth <= 0)
        {
            ResButton.gameObject.SetActive(true);
        }
    }
    public void EnemyHit()
    {
        EnemyHealth -= 20;
        healthBar.fillAmount = EnemyHealth/100f;

        EnemyHealthText.GetComponent<TMPro.TextMeshProUGUI>().text = EnemyHealth.ToString();
        EnemyHealthText.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Debug.Log("Ouch!");

        CoinCount += 10;
        CoinText.GetComponent<TMPro.TextMeshProUGUI>().text = CoinCount.ToString();
    }

    public void DefensePlaced()
    {
        CoinCount -= 40;
        CoinText.GetComponent<TMPro.TextMeshProUGUI>().text = CoinCount.ToString();
    }

    public void TowerHit()
    {
        TowerHealth -= 20;
        TowerHealthText.GetComponent<TMPro.TextMeshProUGUI>().text = TowerHealth.ToString();
        TowerHealthText.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Debug.Log("Ahh!");
    }
}
