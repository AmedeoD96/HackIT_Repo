using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColoreIniziale : MonoBehaviour
{
    public GameObject Tab1;
    public GameObject Tab2;
    public GameObject Tab3;
    void Start()
    {
        Tab1.GetComponent<Image>().enabled = false;
    }

    public void SelezioneTab1()
    {
        Tab1.GetComponent<Image>().enabled = false;
        Tab2.GetComponent<Image>().enabled = true;
        Tab3.GetComponent<Image>().enabled = true;
    }

    public void SelezioneTab2()
    {
        Tab1.GetComponent<Image>().enabled = true;
        Tab2.GetComponent<Image>().enabled = false;
        Tab3.GetComponent<Image>().enabled = true;
    }

    public void SelezioneTab3()
    {
        Tab1.GetComponent<Image>().enabled = true;
        Tab2.GetComponent<Image>().enabled = true;
        Tab3.GetComponent<Image>().enabled = false;
    }
}
