using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startWalk : MonoBehaviour
{ 
    private Transform player;
    private Rigidbody2D rb;
    public float speed=0f;
    [SerializeField] private string triggeringTag = "Player" ;



    bool firstUpdate = false;

    //  private void Update(){ 
    //     if(firstUpdate){
    //         speed=3f;
    //         rb.constraints = RigidbodyConstraints2D.None;
    //     }
        
    // }
    
    
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("wasTrigger");
        if (other.tag == triggeringTag) {
            Debug.Log("inside if");
            player = other.gameObject.transform;
            player = other.gameObject.transform;
            rb = player.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.None;
            speed=3f;
        }
    }
}
