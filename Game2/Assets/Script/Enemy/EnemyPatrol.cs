using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{


    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfoDown = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D groundInfoRight = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);
        RaycastHit2D groundInfoLeft = Physics2D.Raycast(groundDetection.position, Vector2.left, distance);

        if(groundInfoDown.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        if(groundInfoRight.collider == true)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
        } else if(groundInfoLeft.collider == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }

	}
}
