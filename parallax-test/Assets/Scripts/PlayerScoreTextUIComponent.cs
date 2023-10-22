using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreTextUIComponent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    PlayerScoreComponent playerScore;
    private void OnEnable()
    {

        playerScore = FindFirstObjectByType<PlayerScoreComponent>();
        PlayerScoreComponent.PlayerScoreEvent += UpdateScore;
        UpdateScoreManual();
    }

    private void OnDisable()
    {
        PlayerScoreComponent.PlayerScoreEvent -= UpdateScore;
    }

    private void UpdateScoreManual()
    {
        scoreText.text = playerScore.GetScore().ToString();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
