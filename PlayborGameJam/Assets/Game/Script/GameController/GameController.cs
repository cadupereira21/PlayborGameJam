using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public GameObject startButton;
    public bool isGameRunning;

    public void Awake()
    {
        isGameRunning = false;
    }

    public void Start()
    {
        startButton.SetActive(true);
    }

    public void Update()
    {
        if (isGameRunning)
        {
            Time.timeScale = 1.0f;
        } else
        {
            Time.timeScale = 0.0f;
        }
    }

    public void GameOver()
    {
        isGameRunning = false;
        FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_0);
        FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_1);
        FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_2);
    }

    public void GameStart()
    {
        isGameRunning = true;
        startButton.SetActive(false);
        player.SetStepSound();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("FirstLevel");
        startButton.SetActive(true);
    }
}
