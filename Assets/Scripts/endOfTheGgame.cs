using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfTheGgame : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private string triggeringTag = "Player";

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("inside");
        if (other.tag == triggeringTag) {
            NextScene(sceneName);
        }
    }

    public void NextScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
