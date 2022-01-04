using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void NextScene(){
        SceneManager.LoadScene(sceneName);
    }

}
