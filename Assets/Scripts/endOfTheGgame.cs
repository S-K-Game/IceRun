using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfTheGgame : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField]  GameObject passedTxt;
    private string triggeringTag = "Player";
    

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("inside");
        if (other.tag == triggeringTag) {
            passedTxt.SetActive(true);
            StartCoroutine(waitSome());
            //NextScene(sceneName);
        }
    }

    public void NextScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator waitSome(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }
}
