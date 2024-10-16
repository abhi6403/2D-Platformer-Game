using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.KillPlayer();
        }
    }
}
