using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;
    public float speedMove = 50f;
    public float powerJump = 100f;
    bool moveRight, moveLeft;
    public bool flip;
    public int pindah;
    CheckOnGround variableCOG;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        variableCOG = GameObject.Find("Tilemap").GetComponent<CheckOnGround>();
	}
	
	// Update is called once per frame
	void Update () {
        move();

        //CheckOnGround COG = GameObject.FindObjectOfType(typeof(CheckOnGround)) as CheckOnGround;
        //if (COG.onGround == true)
        if (variableCOG.onGround == true)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }
    }

    void move()
    {
        if (Input.GetKey(KeyCode.D) || moveRight == true)
        {
            anim.SetBool("Walk", true);
            transform.Translate(Vector2.right * speedMove * Time.deltaTime, 0);
            pindah = -1;
        }
        else if (Input.GetKey(KeyCode.A) || moveLeft == true)
        {
            anim.SetBool("Walk", true);
            transform.Translate(Vector2.left * speedMove * Time.deltaTime, 0);
            pindah = 1;
        } else
        {
            anim.SetBool("Walk", false);
        }

        if (pindah > 0 && !flip)
        {
            FlipPlayer();
        }
        else if (pindah < 0 && flip)
        {
            FlipPlayer();
        }

        jump();
    }

    public void jump()
    {
        //CheckOnGround COG = GameObject.FindObjectOfType(typeof(CheckOnGround)) as CheckOnGround;
        //if (Input.GetKeyDown(KeyCode.Space) && COG.onGround == true)
        if (Input.GetKeyDown(KeyCode.Space) && variableCOG.onGround == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, powerJump));
            //COG.onGround = false;
            variableCOG.onGround = false;
        } 
    }

    void FlipPlayer()
    {
        flip = !flip;
        Vector3 charakter = transform.localScale;
        charakter.x *= -1;
        transform.localScale = charakter;

    }

    public void btnJump()
    {
        //CheckOnGround COG = GameObject.FindObjectOfType(typeof(CheckOnGround)) as CheckOnGround;
        //if (COG.onGround == true)
        if (variableCOG.onGround == true)
        {
            
            rb.AddForce(new Vector2(rb.velocity.x, powerJump));
            //COG.onGround = false;
            variableCOG.onGround = false;
        }
        
    }

    public void btnMoveRightDown()
    {
        moveRight = true;
    }

    public void btnMoveRightUp()
    {
        moveRight = false;
    }

    public void btnMoveLeftDown()
    {
        moveLeft = true;
    }

    public void btnMoveLeftUp()
    {
        moveLeft = false;
    }


}
