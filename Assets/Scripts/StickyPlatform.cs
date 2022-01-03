using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    [SerializeField] private Rigidbody2D player;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<PlayerMovment>().onPlatform=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.GetComponent<PlayerMovment>().onPlatform=false;
            collision.gameObject.GetComponent<PlayerMovment>().offPlatform();
            //collision.gameObject.transform.velocity.x = 1f;
            
        }
    }
}
