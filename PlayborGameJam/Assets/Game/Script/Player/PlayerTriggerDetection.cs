using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CollidersTag
{
    public const string Stone = "Stone";
}

public class PlayerTriggerDetection : MonoBehaviour
{
    PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CollidersTag.Stone))
        {
            Debug.Log("Player tropeçou em " + collision.tag);
            player.lifes -= 1;
            Debug.Log("Vidas restantes = " + player.lifes);
        }
    }
}
