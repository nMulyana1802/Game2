using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    public Sprite redCheck;
    public Sprite greenCheck;
    private SpriteRenderer checkPointSprite;
    public bool checkPointReached;

	// Use this for initialization
	void Start () {

        checkPointSprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            checkPointSprite.sprite = greenCheck ;
            checkPointReached = true;
        }
    }

}
