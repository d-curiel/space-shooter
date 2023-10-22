using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreEntryComponent : MonoBehaviour
{
    [SerializeField]
    public TMP_Text nicknameText;
    [SerializeField]
    public TMP_Text scoreText;

    public void Init(string nickname, int score)
    {
        nicknameText.text = nickname;
        scoreText.text = score.ToString();
    }

}
