using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreSaveComponent : MonoBehaviour
{

    [SerializeField] AlphabetNavigationComponent letterNickname1;
    [SerializeField] AlphabetNavigationComponent letterNickname2;
    [SerializeField] AlphabetNavigationComponent letterNickname3;
    [SerializeField]
    public TMP_Text score;



    
    public void SaveHighScore()
    {
        string nickname = string.Concat(letterNickname1.GetLetter(),letterNickname2.GetLetter(),letterNickname3.GetLetter());
        HighscoreManager.Instance.AddHighScore(nickname, int.Parse(score.text));
    }


}
