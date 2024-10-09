using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIController : MonoBehaviour
{
    public static int health;

    public GameObject heart0, heart1, heart2; //heart3;

    private void Start()
    {
        health = 4;
        heart0.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        //heart3.gameObject.SetActive(true);
    }

    private void Update()
    {
        switch (health)
        {
            case 4:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                //heart3.gameObject.SetActive(true);
                break;

            case 3:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                //heart3.gameObject.SetActive(true);
                break;

            case 1:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                //heart3.gameObject.SetActive(true);
                break;

            case 0:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                //heart3.gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }
}
