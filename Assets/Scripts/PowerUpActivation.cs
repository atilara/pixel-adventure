using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isPowerUp)
        {
            animator.SetBool("power_up_active", true);
        }
        else
        {
            animator.SetBool("power_up_active", false);
        }
    }


}
