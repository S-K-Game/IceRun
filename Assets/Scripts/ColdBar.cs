using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdBar : MonoBehaviour
{
    public Slider slider;

    public void setMax(int maxValue){
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }
    public void setCold(int cold){
        slider.value = cold;
    }
    public int getCold(){
        return (int)slider.value;
    }

}
