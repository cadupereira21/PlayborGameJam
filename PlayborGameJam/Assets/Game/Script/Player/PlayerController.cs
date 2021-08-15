using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    public Animator animator;

    int playerActualLane;
    int playerActualLaneOld;

    public int lifes;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerRigidbody.transform.localPosition = new Vector3(-5, 0.5f, 0);

        playerActualLane = 1;
        playerActualLaneOld = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && playerActualLane != 2)
        {
            playerRigidbody.transform.SetPositionAndRotation(new Vector3(playerRigidbody.transform.position.x, playerRigidbody.transform.position.y + 2.5f, playerRigidbody.transform.position.z), new Quaternion(0, 0, 0, 0));
            playerActualLane += 1;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && playerActualLane != 0)
        {
            playerRigidbody.transform.SetPositionAndRotation(new Vector3(playerRigidbody.transform.position.x, playerRigidbody.transform.position.y - 2.5f, playerRigidbody.transform.position.z), new Quaternion(0, 0, 0, 0));
            playerActualLane -= 1;
        }

        if(playerActualLane != playerActualLaneOld)
        {
            playerActualLaneOld = playerActualLane;
            SetStepSound();
        }
    }

    public void SetStepSound()
    {
        //FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_0);
        //FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_1);
        //FindObjectOfType<AudioManager>().StopStepSound(GameSounds.LaneStep_2);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_0, 0f);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_1, 0f);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_2, 0f);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound0, 0f);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound1, 0f);
        FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound2, 0f);

        switch (playerActualLane)
        {
            case 0:
                FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_0, 1f);
                FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound0, 1f);
                break;
            case 1:
                FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_1, 1f);
                FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound1, 1f);
                break;
            case 2:
                FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneStep_2, 1f);
                FindObjectOfType<AudioManager>().SetVolume(GameSounds.LaneSound2, 1f);
                break;
        }
    }
}
