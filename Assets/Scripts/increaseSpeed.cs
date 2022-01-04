using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseSpeed : MonoBehaviour
{
    PlayerMovment player;
    
    [SerializeField] private string triggeringTag = "Player" ;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == triggeringTag) {
            player=other.GetComponent<PlayerMovment>();
            Destroy(this.gameObject);
            StartCoroutine(SpeedBoost());
          
        }
    }

    private IEnumerator SpeedBoost(){
        player.speed=5f;
        yield return new WaitForSeconds(0.6f);
        player.speed=3f;
    }
}
