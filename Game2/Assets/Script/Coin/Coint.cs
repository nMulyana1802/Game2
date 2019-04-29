using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour {

    GamePlay GP;

    private void Start()
    {
        GP = GameObject.Find("GamePlayManage").GetComponent<GamePlay>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GP.cointCollect += 1;
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        GP.cointCollect += 1 ;
    //        Destroy(gameObject);
    //    }
    //}
}
