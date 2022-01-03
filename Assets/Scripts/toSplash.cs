using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class toSplash : MonoBehaviour
{
    [SerializeField] private string sceneName;
        void Start()
        {
            StartCoroutine(ToSplash());
        }

    IEnumerator ToSplash (){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene (sceneName);
    }
}
