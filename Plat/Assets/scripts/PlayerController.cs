using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Use this for initialization
    enum Arrow
    {
        Up,
        Right,
        Down,
        Left
    }
    private Vector3 Target;
    private float Step;

    void Start () {
        Step = 2 * Time.deltaTime;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Target != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, Target, Step);


        if (Input.GetMouseButtonDown(0))
        {
            ScreenMouseRay();
            //Target = new Vector3(worldPosition.x , worldPosition.y, transform.position.z);
            //Debug.Log("Target Position: " + worldPosition.x + ", " + worldPosition.y);
        }

    }

    // get direction for movement
    void Movement(Arrow direction)
    {
        switch (direction)
        {
            case Arrow.Up:
                Target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                break;
            case Arrow.Right:
                Target = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                break;
            case Arrow.Down:
                Target = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                break;
            case Arrow.Left:
                Target = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                break;
        }
    }
    public void ScreenMouseRay()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5f;

        Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

        Collider2D[] col = Physics2D.OverlapPointAll(v);

        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            {
                Debug.Log("Collided with: " + c.GetComponent<Collider2D>().gameObject.name);
                switch (c.GetComponent<Collider2D>().gameObject.name)
                {
                    case "Up":
                        Movement(Arrow.Up);
                        break;
                    case "Right":
                        Movement(Arrow.Right);
                        break;
                    case "Down":
                        Movement(Arrow.Down);
                        break;
                    case "Left":
                        Movement(Arrow.Left);
                        break;
                }
            }
        }
    }
}
