using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5;

    public float JumpForce = 10;

    public bool isJumping = false;

    public bool doubleJump = false;

    private Rigidbody2D rig;

    private Animator animator;

    public TextMeshProUGUI powerUpCountText;

    public static int powerUpCount = 01;

    public static bool isPowerUp = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        powerUpCountText = GameObject.Find("PowerUpText").GetComponent<TextMeshProUGUI>();
        powerUpCountText.text = "0" + powerUpCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        PowerUp();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("run", true);
            return;
        }

        if (movement < 0f)
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
                animator.SetBool("double_jump", true);
                doubleJump = false;
            }

        }
    }

    public void PowerUp()
    {

        if (powerUpCount <= 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            
            powerUpCount--;
            powerUpCountText.text = "00";
            isPowerUp = true;
            Invoke("DeactivatePowerUp", 7);
        }
    }

    void DeactivatePowerUp()
    {
        Debug.Log("DeactivatePowerUp");
        isPowerUp = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = false;
            animator.SetBool("jump", false);
            animator.SetBool("double_jump", false);
        }

        if (col.gameObject.CompareTag("Dangerous") && !isPowerUp)
        {
            GameController.instance.totalScore = 0;
            GameController.instance.UpdateScoreText();
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
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
