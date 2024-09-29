using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator animator;
    //public BoxCollider2D collider;
    private float crouchHeight = 1f;
    private float standHeight = 2f;

    private void Update()
    {
        runAnimation();
        crouchAnimation();
        jumpAnimation();
    }

    private void runAnimation()
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

    private void crouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Crouch", true);
        } else
        {
            animator.SetBool("Crouch",false);
        }
    }
    private void jumpAnimation()
    {
        float jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", jump);

    }
}
