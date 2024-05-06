using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;

    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;

    public GameObject pause;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game if the player presses escape
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
}
