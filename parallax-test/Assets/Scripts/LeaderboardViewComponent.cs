using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardViewComponent : MonoBehaviour
{
    [SerializeField] private Transform m_ContentContainer;
    [SerializeField] private GameObject m_ItemPrefab;

    private void OnEnable()
    {
        List<HighScoreEntry> highScores = HighscoreManager.Instance.LoadScores();
        foreach(HighScoreEntry highScore in highScores){

            var item_go = Instantiate(m_ItemPrefab);
            item_go.TryGetComponent<HighScoreEntryComponent>(out HighScoreEntryComponent hScomponent);
            hScomponent.Init(highScore.nickname, highScore.score);
            item_go.transform.SetParent(m_ContentContainer);
            item_go.transform.localScale = Vector2.one;
        }
    }


    private void OnDisable()
    {
        m_ContentContainer.transform.Clear();
    }
}
