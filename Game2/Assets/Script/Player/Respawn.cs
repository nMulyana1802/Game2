using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Vector2 spawning;
    public bool spawn;

    // Use this for initialization
    void Start () {

        spawning = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(spawn == true)
        {
            transform.position = spawning;
            spawn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CheckPoint")
        {
            spawning = collision.transform.position;
        }
    }

}
