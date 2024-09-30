using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playercollider;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;

    private void Start()
    {
        boxColliderSize = playercollider.size;
        boxColliderOffset = playercollider.offset;
    }
    public void Update()
    {
        runAnimation();
        crouchAnimation();
        jumpAnimation();
    }

    public void runAnimation()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
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
    public void jumpAnimation()
    {
        float jump = Input.GetAxis("Vertical");
        if(jump > 0 )
        {
            animator.SetTrigger("Jump");
        }
    }
}
