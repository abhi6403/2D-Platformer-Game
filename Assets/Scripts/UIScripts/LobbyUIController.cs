using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour
{
    public Button playButton;
    public GameObject levelSelection;
    public Button quitButton; 


    public void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        PlayerPrefs.DeleteAll();
    }

    private void PlayGame()
    { 
        SoundManager.Instance.Play(Sounds.BUTTONCLICK);
        levelSelection.SetActive(true);
    }

    private void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.BUTTONCLICK);
        Application.Quit();
    }
}
