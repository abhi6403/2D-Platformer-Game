using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Animator playeranimator;
    public BoxCollider2D playercollider;
    public ScoreController scoreController;
    public GameOverController gameOverController;

    public float speed;
    public float jumpForce;
    public List<GameObject> hearts;

    private int playerLives = 3;
    private bool movePlayer = false;
    private bool crouch;
    private bool isDead = false;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;
    private Rigidbody2D playerRigidBody;
    private Camera mainCamera;

    private bool isGrounded = false;

    private void Start()
    {
        mainCamera = Camera.main;
        boxColliderSize = playercollider.size;
        boxColliderOffset = playercollider.offset;

        playerRigidBody =  GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (isDead == false)
        {
            if (isGrounded == true)
            {
                movePlayer = true;
            }
            else
            {
                movePlayer = false;
            }


            float horizontal = Input.GetAxisRaw("Horizontal");

            HorizontalAnimation(horizontal);
            playerJumpMovement();
            playerMovement(horizontal);
            crouchMovement();
        }
    }

    private void HorizontalAnimation(float horizontal)
    {
        if (movePlayer == true)
        {
            if(horizontal > 0)
            {
                playeranimator.SetFloat("speed", Mathf.Abs(horizontal));
            }else
            {
                playeranimator.SetFloat("speed", 0);
            }
        }
        
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

    void playerJumpMovement()
    {
        //Jump movement
        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playeranimator.SetTrigger("Jump");
        }
    }

    public void crouchMovement()
    {
        //Crouch movement
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            float offX = 0.000975f;
            float offY = 0.5f;

            float sizeX = 0.33f;
            float sizeY = 1.02f;

            playercollider.size = new Vector2(sizeX, sizeY);
            playercollider.offset = new Vector2(offX, offY);
            playeranimator.SetBool("Crouch", crouch);

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            playercollider.size = boxColliderSize;
            playercollider.offset = boxColliderOffset;
            playeranimator.SetBool("Crouch", crouch);
        }


    }


    public void PickUpKey()
    {
        Debug.Log("Picked up the key");
        scoreController.IncreaseScore(10);
    }
    
    public void KillPlayer()
    {
        if(playerLives >= 1)
        {
            ReducePlayerLives();
        } 
        else if(playerLives == 0) 
        {
            PlayerDeath();
        }
    }

    public void ReducePlayerLives()
    {
        playerLives--;
        hearts[playerLives].SetActive(false);
        SoundManager.Instance.Play(Sounds.PLAYERHEALTH);
        Debug.Log("reduced lives by one");
    }
    private void PlayerDeath()
    {
        SoundManager.Instance.Play(Sounds.PLAYERDEATH);
        playeranimator.SetTrigger("Death");
        isDead = true;
        mainCamera.transform.parent = null;
        Debug.Log("Player is Dead");
        gameOverController.PlayerDied();
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
