using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public GameObject startButton;
    public Canvas hud;
    public bool isGameRunning;
    //public static float levelSpeed = 1f; usar para pausar e despausar a fase?

    public void Awake()
    {
        isGameRunning = false;
    }

    public void Start()
    {
        startButton.SetActive(true);
        FindObjectOfType<AudioManager>().Play(GameSounds.Theme);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_0, 0.3f);
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
            hud.gameObject.SetActive(true);
        } else
        {
            Time.timeScale = 0.0f;
            hud.gameObject.SetActive(false);
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
        FindObjectOfType<AudioManager>().StopSound(GameSounds.VictorySound);
        FindObjectOfType<AudioManager>().StopSound(GameSounds.GameOverSound);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.Theme, 0.3f);
        startButton.SetActive(true);
    }
}
