using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int leftScore;
    private int rightScore;
    public Text leftScoreText;
    public Text rightScoreText;

    public Text resultText;
    public Button replayButton;
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        replayButton.onClick.AddListener(delegate { RestartGame(); });
    }

    public void AddScore(bool isLeftwin)
    {
        if(isLeftwin)
        {
            leftScore++;
            leftScoreText.text = leftScore.ToString();
        }
        else
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
        }

        if (leftScore >= 10 || rightScore >= 10)
            EndGame();
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        resultText.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        if (leftScore>rightScore)
        {
            resultText.text = "Player1 Win!";
        }
        else if(rightScore>leftScore)
        {
            resultText.text = "Player2 Win!";
        }
        else
        {
            resultText.text = "Draw";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
