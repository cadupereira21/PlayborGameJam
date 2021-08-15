using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossController : MonoBehaviour
{
    public PlayerController player;
    public Timer clock;
    public GameObject winCanvas;
    public GameObject lossCanvas;
    GameController gameController;

    public static bool isAWin;
    public static bool isALoss;

    [SerializeField] int timeLimit = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        isAWin = false;
        isALoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.lifes < 1)
        {
            LoseGame();
        }
        if(clock.minutes >= timeLimit)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (isAWin)
        {
            return;
        }
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.Theme, 0f);
        FindObjectOfType<AudioManager>().Play(GameSounds.VictoryVoice);
        FindObjectOfType<AudioManager>().Play(GameSounds.VictorySound);
        Debug.LogWarning("Você venceu!");
        winCanvas.SetActive(true);
        gameController.GameOver();
        isAWin = true;
        isALoss = false;
    }

    void LoseGame()
    {
        if (isALoss)
        {
            return;
        }
        //Time.timeScale = 1.0f;
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.Theme, 0f);
        FindObjectOfType<AudioManager>().Play(GameSounds.GameOverVoice);
        FindObjectOfType<AudioManager>().Play(GameSounds.GameOverSound);
        //Time.timeScale = 0.0f;
        Debug.LogWarning("Você Perdeu!");
        lossCanvas.SetActive(true);
        gameController.GameOver();
        isAWin = false;
        isALoss = true;
    }

    public void RestartButton()
    {
        gameController.RestartLevel();
        isAWin = false;
        isALoss = false;
        player.lifes = 5;
        clock.minutes = 0;
        clock.seconds = 0;
    }
}
