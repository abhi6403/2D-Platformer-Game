using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public float speed;
    public Transform GroundCheck;
    public float radius;

    bool isRight = true;

    private void Update()
    {
        //patrolling movement
        transform.Translate(Vector2.right * speed *  Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(GroundCheck.position, Vector2.down, radius);

        if(hitInfo.collider == false )
        {
            if(isRight == true)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                isRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //reducing player life on collision
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.KillPlayer();
        }
    }
}
