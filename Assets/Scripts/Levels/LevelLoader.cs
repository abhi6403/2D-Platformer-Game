using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        //Checking level status
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.BUTTONCLICK);
                SceneManager.LoadScene(LevelName);
                break;

        }
        
    }
}
