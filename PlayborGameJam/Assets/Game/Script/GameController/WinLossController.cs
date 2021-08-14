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
        if(player.lifes <= 0)
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
        Debug.LogWarning("Você venceu!");
        winCanvas.SetActive(true);
        gameController.GameOver();
        isAWin = true;
        isALoss = false;
    }

    void LoseGame()
    {
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
