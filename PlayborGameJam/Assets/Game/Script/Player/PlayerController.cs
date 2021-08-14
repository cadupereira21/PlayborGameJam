using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;

    int playerActualLane;

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
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && playerActualLane != 0)
        {
            playerRigidbody.transform.SetPositionAndRotation(new Vector3(playerRigidbody.transform.position.x, playerRigidbody.transform.position.y - 2.5f, playerRigidbody.transform.position.z), new Quaternion(0, 0, 0, 0));
            playerActualLane -= 1;
        }
    }
}
