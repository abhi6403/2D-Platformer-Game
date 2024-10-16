using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 

    public GameObject player;
    public Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //respawn when fall down
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.KillPlayer();
            player.transform.position = respawnPoint.position;
        }
    }
}
