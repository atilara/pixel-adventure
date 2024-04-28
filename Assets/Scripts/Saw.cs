using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed = 5f;

    public float moveTime = 2f;
    
    private bool movingRight = true;

    private float timer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            movingRight = !movingRight;
            timer = 0f;
        }
        
    }
}
