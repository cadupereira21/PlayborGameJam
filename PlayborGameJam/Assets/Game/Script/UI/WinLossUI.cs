using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossUI : MonoBehaviour
{
    public GameController gameController;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
            gameController.RestartLevel();
        }
    }
}
