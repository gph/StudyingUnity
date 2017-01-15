using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Use this for initialization
    private Vector3 Target;
    private float Step;

    void Start () {
        Step = 2 * Time.deltaTime;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(Target != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, Target, Step);


        if (Input.GetKeyDown("left"))
        {

            Target = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            Debug.Log("left: (" + Target.x + ", " + Target.y + ")");
        }
        if (Input.GetKeyDown("right"))
        {

            Target = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            Debug.Log("right: (" + Target.x + ", " + Target.y + ")");

        }
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("up");
            //Target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
        if (Input.GetKeyDown("down"))
        {
            Debug.Log("down");
            //Target = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }

    }
}
