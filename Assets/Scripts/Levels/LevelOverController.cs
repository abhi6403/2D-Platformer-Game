using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{ 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<playerController>() != null)
        {
            Debug.Log("Level Completed");
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}
