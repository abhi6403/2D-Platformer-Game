using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<playerController>()  != null)
        {
            //Collecting key
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.PickUpKey();
            Destroy(gameObject);
        }
    }
}
