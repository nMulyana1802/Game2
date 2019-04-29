using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnGround : MonoBehaviour {

    public bool onGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            onGround = true;
        }
        else if (!collision.gameObject.tag.Equals("Player"))
        {
            onGround = false;
        }
    }
}
