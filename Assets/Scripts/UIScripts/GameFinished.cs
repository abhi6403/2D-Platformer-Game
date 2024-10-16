using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinished : MonoBehaviour
{
    public Button lobbyButton;
    public GameObject gameFinished;

    private void Awake()
    {
        lobbyButton.onClick.AddListener(loadLobby);
        gameFinished.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            Debug.Log("Level Completed");
            gameFinished.SetActive(true);
        }
    }

    private void loadLobby()
    {
        SceneManager.LoadScene(0);
    }
}
