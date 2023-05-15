using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Bird bird;
    public Text scoreText;
    public GameObject scoreObject;
    public GameObject tapToPlay;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        tapToPlay.SetActive(true);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        scoreObject.SetActive(false);
        Pause();
    }

    public void Play()
    {
        tapToPlay.SetActive(false);
        scoreObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RePlay()
    {
        score = 0;
        scoreText.text = score.ToString();

        tapToPlay.SetActive(true);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        scoreObject.SetActive(false);

        Pipe[] pipes = FindObjectsOfType<Pipe>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        bird.enabled = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        bird.enabled = false;

        Pause();
    }
}
