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
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.reducePlayerHealth();
            player.transform.position = respawnPoint.position;
        }
        /*if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;

        }*/
    }

    /*public void restartLevel()
    {
        Time.timeScale = 1.0f;
        HealthUIController.health = 4;
        SceneManager.LoadScene(0);
    }*/
}
