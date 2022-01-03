using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    [SerializeField] private string triggeringTag ;
    private bool firstUpdate=false;
    
  
    private void Update(){ 
        if(firstUpdate)
            camera.position = new Vector3(player.position.x, camera.position.y, camera.position.z);
        
    }

    private void OnTriggerEnter2D(Collider2D other){
           firstUpdate=true;
           player = other.gameObject.transform;
    }

   
}
