using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreComponent : MonoBehaviour
{
    int score = 10;
    public delegate void EnemyScoreDelegate(int score);
    public static event EnemyScoreDelegate EnemyScoreEvent;

    public void GiveScore()
    {
        if (EnemyScoreEvent != null)
        {
            EnemyScoreEvent(score);
        }
    }
}
