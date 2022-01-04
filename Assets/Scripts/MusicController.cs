using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private AudioSource aso;
    [SerializeField]  GameObject buttonOn;
    [SerializeField]  GameObject buttonOff;

    void Start()
    {
        aso = GameObject.Find("Camera").GetComponent<AudioSource>();
    }

    //turn on music
    public void MusicOn(){
        aso.mute = !aso.mute;
        buttonOn.SetActive(false);
        buttonOff.SetActive(true);
    }

    //turn off music
    public void MusicOff(){
        aso.mute = !aso.mute;
        buttonOn.SetActive(true);
        buttonOff.SetActive(false);

    }
}
