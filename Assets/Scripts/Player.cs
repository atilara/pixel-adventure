using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5;

    public float JumpForce = 10;

    public bool isJumping = false;

    public bool doubleJump = false;

    private Rigidbody2D rig;
    private Animator animator;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Speed * Time.deltaTime * movement;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("run", true);
            return;
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            animator.SetBool("run", true);
            return;
        }

        animator.SetBool("run", false);

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                animator.SetBool("jump", true);

                return;
            }

            if (doubleJump)
            {
                rig.AddForce(new Vector2(0f, JumpForce / 1.5f), ForceMode2D.Impulse);
                doubleJump = false;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = false;
            animator.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}
