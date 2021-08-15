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
        FindObjectOfType<AudioManager>().Play(GameSounds.Theme);
        FindObjectOfType<AudioManager>().Play(GameSounds.LaneStep_0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_0, 0);
        FindObjectOfType<AudioManager>().Play(GameSounds.LaneStep_1);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_1, 0);
        FindObjectOfType<AudioManager>().Play(GameSounds.LaneStep_2);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_2, 0);
        FindObjectOfType<AudioManager>().Play(GameSounds.LaneSound0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound0, 0);
        FindObjectOfType<AudioManager>().Play(GameSounds.LaneSound1);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound1, 0);
        FindObjectOfType<AudioManager>().Play(GameSounds.LaneSound2);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound2, 0);
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
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_0, 0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_1, 0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_2, 0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound0, 0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound1, 0);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound2, 0);
    }

    public void GameStart()
    {
        isGameRunning = true;

        player.SetStepSound();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("FirstLevel");
        startButton.SetActive(true);
    }
}
