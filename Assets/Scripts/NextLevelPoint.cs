using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    private Animator animator;

    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("level_ended", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        animator.SetBool("level_ended", true);
        Invoke("NextLevel", 1f);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
        Player.isPowerUp = false;
    }
}
