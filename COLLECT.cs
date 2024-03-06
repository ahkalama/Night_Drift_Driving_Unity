using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COLLECT : MonoBehaviour
{
    public GameObject Scoretext;
    public static int score;

    public Text scoreDisplayText;
    public Text higScoreDisplayText;

    void Update()
    {
        Scoretext.GetComponent<Text>().text = "Score : " + score;

        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    private void Start()
    {
        scoreDisplay();
        highscoreDisplay();
    }

    private void scoreDisplay()
    {
        scoreDisplayText.text = score.ToString();
    }

    private void highscoreDisplay()
    {
        score = 0;
        higScoreDisplayText.text = PlayerPrefs.GetInt("highscore").ToString(); // highscore u int olarak alıp tostringle string e çeviriyoruz
    }
}
