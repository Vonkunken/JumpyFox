using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject restartButton;
    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
        restartButton.SetActive(false);
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "";
        scoreText.text = "SCORE: " + score.ToString();
    }


    void Update()
    {

    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "SCORE: " + score.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void EndGame()
    {
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
        restartButton.SetActive(true);
    }
}
