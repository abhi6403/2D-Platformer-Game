using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator playeranimator;
    public BoxCollider2D playercollider;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool crouch;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;
    private Rigidbody2D playerRigidBody;

    private bool isGrounded = false;

    private void Start()
    {
        boxColliderSize = playercollider.size;
        boxColliderOffset = playercollider.offset;

        playerRigidBody =  GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        HorizontalAnimation(horizontal);
        playerJumpMovement(vertical);
        playerMovement(horizontal);
        crouchMovement();
        //crouchAnimation();
    }

    private void HorizontalAnimation(float horizontal)
    {
        
        playeranimator.SetFloat("speed", Mathf.Abs(horizontal));

        //Running animation
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    public void playerMovement(float horizontal)
    {
        //Horizontal movement
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        
    }

    void playerJumpMovement(float vertical)
    {
        if (vertical >  0)// && isGrounded)
        {
            playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playeranimator.SetTrigger("Jump");
        }
    }

    public void crouchMovement()
    {
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            float offX = 0.000975f;
            float offY = 0.5f;

            float sizeX = 0.33f;
            float sizeY = 1.02f;

            playercollider.size = new Vector2(sizeX, sizeY);
            playercollider.offset = new Vector2(offX, offY);
            playeranimator.SetBool("Crouch",crouch); 

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            playercollider.size = boxColliderSize;
            playercollider.offset = boxColliderOffset;
            playeranimator.SetBool("Crouch", crouch);
        }
    }

   /* private void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    /*bool isGrounded()
   {
       return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.58f, 0.07f), CapsuleDirection2D.Horizontal, 0,groundLayer);
   }

    /*public void crouchAnimation()
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
        playeranimator.SetBool("Crouch",crouch);
    }*/
}
