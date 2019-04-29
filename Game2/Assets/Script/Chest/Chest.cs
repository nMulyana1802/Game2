using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    GamePlay gp;
    Animator anim;


    private void Start()
    {
        gp = GameObject.Find("GamePlayManage").GetComponent<GamePlay>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gp.cointCollect >= gp.targetCoint)
            {
                anim.SetBool("UnlockChest", true);
                gp.gameComplete();
                SaveManager.instance.LevelUP();
                
            }
            else
            {
               
                gp.Aler = true;
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gp.Aler = false;
        }
    }
}
