using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showText : MonoBehaviour
{
   [SerializeField] GameObject text;
   private string triggeringTag = "Player";

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == triggeringTag) {
            StartCoroutine(waitAndHide());
        }
    }

    private IEnumerator waitAndHide(){
        text.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        text.SetActive(false);
    }
}
