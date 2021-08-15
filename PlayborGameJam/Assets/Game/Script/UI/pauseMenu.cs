using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameController gameController;

    public void ResumeGame()
    {
        gameController.isGameRunning = true;
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo");
        Application.Quit();
    }
}
