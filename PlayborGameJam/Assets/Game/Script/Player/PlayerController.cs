using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;

    int playerActualLane;

    public int lifes;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerRigidbody.transform.localPosition = new Vector3(-5, -0.5f, 0);

        playerActualLane = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && playerActualLane != 2)
        {
            playerRigidbody.transform.SetPositionAndRotation(new Vector3(playerRigidbody.transform.position.x, playerRigidbody.transform.position.y + 2.5f, playerRigidbody.transform.position.z), new Quaternion(0, 0, 0, 0));
            playerActualLane += 1;
            SetStepSound();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && playerActualLane != 0)
        {
            playerRigidbody.transform.SetPositionAndRotation(new Vector3(playerRigidbody.transform.position.x, playerRigidbody.transform.position.y - 2.5f, playerRigidbody.transform.position.z), new Quaternion(0, 0, 0, 0));
            playerActualLane -= 1;
            SetStepSound();
        }
    }

    public void SetStepSound()
    {
        FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_0);
        FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_1);
        FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_2);

        switch (playerActualLane)
        {
            case 0:
                FindObjectOfType<AudioManager>().Play(GameSounds.LaneStep_0);
                break;
            case 1:
                FindObjectOfType<AudioManager>().Play(GameSounds.LaneStep_1);
                break;
            case 2:
                FindObjectOfType<AudioManager>().Play(GameSounds.LaneStep_2);
                break;
        }
    }
}
