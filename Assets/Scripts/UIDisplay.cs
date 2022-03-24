using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Wave")]
    [SerializeField] TextMeshProUGUI waveText;
    EnemySpawner enemySpawner;


    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000000");
        healthSlider.value = playerHealth.GetHealth();
        waveText.text = "Wave " + enemySpawner.GetCurrentWaveIndex();
    }
}
