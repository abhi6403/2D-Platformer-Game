using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   // float startPosX = -9.22f;
    //float startPosY = -2.38f;

    public GameObject player;
    public Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
        }
    }
}
