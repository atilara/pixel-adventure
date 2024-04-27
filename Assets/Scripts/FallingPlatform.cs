using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private TargetJoint2D targetJoint;

    public float fallDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        targetJoint = GetComponent<TargetJoint2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    void Fall()
    {
        boxCollider.isTrigger = true;
        targetJoint.enabled = false;

    }
}