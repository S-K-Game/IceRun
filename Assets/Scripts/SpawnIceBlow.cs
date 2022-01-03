using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIceBlow : MonoBehaviour
{   
    private Transform player;
    private int randInd;
    [SerializeField] public GameObject _powerUpPrefabs;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
           player = other.gameObject.transform;
           StartCoroutine(SpwanPowerUpRoutine());

    }
    
   IEnumerator SpwanPowerUpRoutine(){
       yield return new WaitForSeconds(4f);
       while(true)
       {
            Vector3 postospawn = new Vector3(Random.Range(player.position.x+0.5f, player.position.x+1f), Random.Range(player.position.y, player.position.y+0.1f), 0);
            GameObject new_powerUp = Instantiate(_powerUpPrefabs, postospawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f,12f));
       }
   }

}
