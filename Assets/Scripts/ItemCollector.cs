using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private string triggeringTag="Coffee";
    public ColdBar coldBar;
    private int coffee = 0;
    private int newCold;

    void Start(){
        coldBar = GameObject.Find("ColdBar1").GetComponent<ColdBar>();
    }
    
   private void OnTriggerEnter2D(Collider2D other){
       if(other.tag == triggeringTag && enabled ){
           newCold = coldBar.getCold() + 5;
           coldBar.setCold(newCold);
           Destroy(other.gameObject);
           coffee ++;
       }
   }
}
