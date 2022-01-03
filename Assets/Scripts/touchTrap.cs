using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchTrap : MonoBehaviour
{
    [SerializeField] private string triggeringTag="Trap";
    private Vector3 DeadPos;
    private Animator animator;
    private Renderer rend;
    private Rigidbody2D rb;
    private bool alreadyDie = false;
    PlayerMovment pm;
    //public GameObject trap;

    private void Start(){
        animator = GetComponent<Animator>();
        rend = gameObject.GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovment>();

    }

    private void OnTriggerEnter2D(Collider2D other){
       if(other.tag == triggeringTag && enabled)
        {
            animator.SetTrigger("trap");
            GameObject trapObject=other.gameObject;
            if(trapObject.name == "Trap"){
                DeadPos = trapObject.transform.Find("DeadPos").position;
            }
            else{
                DeadPos = trapObject.transform.parent.Find("DeadPos").position;
            }
                transform.position = DeadPos;
                StartCoroutine(dead());
       }
   }

   private IEnumerator dead(){
        pm.TakeHit(1);
        GetComponent<PlayerMovment>().dead=true;
        pm.speed = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.None;
        pm.speed = 2;
        GetComponent<PlayerMovment>().dead=false;
    }

}
