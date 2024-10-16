using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public Button nextLevelButton;
    public Button lobbyButton;
    public GameObject levelUp;

    public void Awake()
    {
        nextLevelButton.onClick.AddListener(NextLevel);
        lobbyButton.onClick.AddListener(Lobby);
        levelUp.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<playerController>() != null)
        {
            Debug.Log("Level Completed");
            levelUp.SetActive(true);
            LevelManager.Instance.MarkCurrentLevelComplete();
            
        }
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void Lobby()
    {
        SceneManager.LoadScene(0);
    }
}
