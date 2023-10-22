using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

[System.Serializable]
public class HighScoreEntry
{
    public string nickname;
    public int score;

    public HighScoreEntry()
    {
    }

    public HighScoreEntry(string nickname, int score)
    {
        this.nickname = nickname;
        this.score = score;
    }
}
[System.Serializable]
public class Leaderboard
{
    public List<HighScoreEntry> list;
    public Leaderboard()
    {
        list  = new List<HighScoreEntry>();
    }
    
}
public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance { get; private set; }

    [SerializeField]
    private int maxHighscores = 10;

    private Leaderboard leaderboard = new Leaderboard();
    private string highscoreFileName = "highscores.xml";
    private string dataPath;

    void Awake()
    {
        Instance = this;
        
        
        DontDestroyOnLoad(gameObject);
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath + "/HighScores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/HighScores/");
        }

    }

    public void AddHighScore(string nickname, int score)
    {
        LoadScores();
        List<HighScoreEntry> currentLeaderboard = leaderboard.list;
        if(currentLeaderboard.Count < maxHighscores)
        {
            currentLeaderboard.Add(new HighScoreEntry(nickname, score));
        } else
        {
            int insertIndex = BinarySearchForInsertIndex(currentLeaderboard, score);

            if (insertIndex >= 0)
            {
                currentLeaderboard.Insert(insertIndex, new HighScoreEntry(nickname, score));
                currentLeaderboard.RemoveAt(currentLeaderboard.Count - 1);
            }
        }

        SaveHighscores(currentLeaderboard);
    }

    public List<HighScoreEntry> LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScores/highscores.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            stream.Close();
            ArrangeItems();
        }
        return leaderboard.list;
    }

    public void SaveHighscores(List<HighScoreEntry> scoresToSave)
    {
        leaderboard.list = scoresToSave;
        XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
        FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }

    private int BinarySearchForInsertIndex(List<HighScoreEntry> leaderboard, int newScore)
    {
        int left = 0;
        int right = leaderboard.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (leaderboard[mid].score < newScore)
            {
                right = mid - 1;
            }
            else if (leaderboard[mid].score > newScore)
            {
                left = mid + 1;
            }
            else
            {
                return mid; // Si se encuentra una puntuación igual, no cambiamos el orden.
            }
        }

        return left; // Devuelve la posición donde se debe insertar el nuevo puntaje.
    }

    private void ArrangeItems()
    {
        leaderboard.list.Sort((entry1, entry2) => entry2.score.CompareTo(entry1.score));
    }
}
