using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreComponent : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    public delegate void PlayerScoreDelegate(int score);
    public static event PlayerScoreDelegate PlayerScoreEvent;

    private void Start()
    {
        if (PlayerScoreEvent != null)
        {
            PlayerScoreEvent(this.score);
        }
    }
    private void OnEnable()
    {
        EnemyScoreComponent.EnemyScoreEvent += EarnScore;
    }

    private void OnDisable()
    {
        EnemyScoreComponent.EnemyScoreEvent -= EarnScore;
    }

    public void EarnScore(int score)
    {
        this.score += score;
        if(PlayerScoreEvent != null)
        {
            PlayerScoreEvent(this.score);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
