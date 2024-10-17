using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKillCount : MonoBehaviour
{
    public static int enemyKillCount = 0;
    public TextMeshProUGUI killCountText;

    private void Awake()
    {
        enemyKillCount = 0;
    }
    private void Start()
    {
        UpdateKillCountText();
    }

    public void IncreaseKillCount()
    {
        enemyKillCount++;
        UpdateKillCountText();
    }

    private void UpdateKillCountText()
    {
        killCountText.text = "Enemy kills: " + enemyKillCount;
    }
}
