using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    public static int health;

    public GameObject heart0, heart1, heart2, gameOver;
    public Button restartButton;

    private void Start()
    {
        health = 3;
        heart0.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        
    }

    private void RestartLevel()
    {
        gameOver.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        health = 3;  
    }

    private void Update()
    {
        switch (health)
        {
            case 3:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                break;

            case 2:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                break;

            case 1:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                break;

            default:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                break;

        }

        if(health <= 0)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            restartButton.onClick.AddListener(RestartLevel);
            
        }
    }

    
}
