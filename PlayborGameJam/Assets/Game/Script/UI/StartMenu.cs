using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameController gameController;

    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Escape)))
        {
            this.gameObject.SetActive(false);
            gameController.GameStart();
        }
    }
}
