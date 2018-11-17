using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int highScore;

    private Text text;

    void Awake()
    {
        this.text = this.GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = score.ToString();
    }

    public static void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}