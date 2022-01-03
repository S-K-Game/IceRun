using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Freeze : MonoBehaviour
{
    [SerializeField] private string triggeringTag = "Player" ;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == triggeringTag) {
            Destroy(this.gameObject);
            Debug.Log("Freeze");

            ////////////////////////////////////////
            /**להוסיף קוד להקפאת השחקן השני במשחק*/
        }
    }
}
