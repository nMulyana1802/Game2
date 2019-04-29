using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    Respawn Res;
    
	// Use this for initialization
	void Start () {

        Res = GameObject.Find("Player").GetComponent<Respawn>();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            print("Menyentuh Air");
            SaveManager.instance.LiveMinus();
            Res.spawn = true;

        }
    }


}
