using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button lobbyButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(reloadLevel);
        lobbyButton.onClick.AddListener(loadLobby);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void reloadLevel()
    {
        Debug.Log("Reloading Scene...");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void loadLobby()
    {
        SceneManager.LoadScene(0);
    }
}
