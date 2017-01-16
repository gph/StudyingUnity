using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
            Debug.Log(mouseTarget.x);
            if(mouseTarget.x > transform.position.x)
            {
                rb.velocity = new Vector2(7f, rb.velocity.y);
                transform.localScale = new Vector3(1, 1, 1);
            }
            if(mouseTarget.x < transform.position.x)
            {
                rb.velocity = new Vector2(-7f, rb.velocity.y);
                transform.localScale = new Vector3(-1,1,1);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
