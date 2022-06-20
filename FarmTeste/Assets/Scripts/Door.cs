using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool enter = true;
    [SerializeField] private bool exit;

    private BoxCollider2D box;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            if (enter)
            {
                anim.SetBool("isOpen", true);
                anim.SetBool("IsClose", false);
                enter = false;
                exit = true;
                box.isTrigger = true;

            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (exit)
            {
                anim.SetBool("IsClose", true);
                anim.SetBool("isOpen", false);
                exit = false;
                enter = true;
                box.isTrigger = false;
            }
        }
    }


}
