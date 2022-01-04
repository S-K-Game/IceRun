using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTouch : MonoBehaviour
{

    private Animator animator;
    private Renderer rend;
    private Rigidbody2D rb;
    PlayerMovment pm;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rend = gameObject.GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovment>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="boom" && enabled)
        {
                pm.boom = true;
                animator.SetBool("boom", true);
                Destroy(collision.gameObject);
                StartCoroutine(dead());      
        }

    }


    private IEnumerator dead()
    {
        pm.TakeHit(1);
        GetComponent<PlayerMovment>().dead = true;
        pm.speed = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(1f);
        rb.constraints = RigidbodyConstraints2D.None;
        GetComponent<PlayerMovment>().dead = false;
        pm.speed = 2;
        animator.SetBool("boom", false);
        pm.boom =false;
    }

}
