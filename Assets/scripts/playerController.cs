using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playercollider;
    public float speed;
    public float jump;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;
    private Rigidbody2D playerRigidBody;

    private void Start()
    {
        boxColliderSize = playercollider.size;
        boxColliderOffset = playercollider.offset;

        playerRigidBody =  GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        playerMovementAnimation(horizontal,vertical);
        playerMovement(horizontal, vertical);
        crouchAnimation();
    }

    public void playerMovementAnimation(float horizontal, float vertical)
    {
        
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        //Running animation
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump animation
        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }else
        {
            animator.SetBool("Jump",false);
        }
    }

    public void playerMovement(float horizontal, float vertical)
    {
        //Horizontal movement
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Vertical movement
        if(vertical > 0 )
        {
            playerRigidBody.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }


    public void crouchAnimation()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        } else
        {
            Crouch(false);
        }
    }

    public void Crouch(bool crouch)
    {
        if(crouch == true)
        {
            float offX = 0.000975f;
            float offY = 0.5f;

            float sizeX = 0.33f;
            float sizeY = 1.02f;

            playercollider.size = new Vector2 (sizeX, sizeY);
            playercollider.offset = new Vector2 (offX, offY);
        } else
        {
            playercollider.size = boxColliderSize;
            playercollider.offset = boxColliderOffset;
        }
        animator.SetBool("Crouch",crouch);
    }
}
