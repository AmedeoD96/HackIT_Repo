using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsMenuVertical : MonoBehaviour
{
    public GameObject TestoSuggerimento;
    private int monetine;
    
    // Start is called before the first frame update
    void Start()
    {
        monetine = PlayerPrefs.GetInt("monetine");
        TestoSuggerimento.SetActive(false);
    }


    public void SuggerimentoUno()
    {
        if (monetine >= 2){
            TestoSuggerimento.SetActive(true);
            PlayerPrefs.SetInt("monetine", PlayerPrefs.GetInt("monetine")-2);
        }
        else{
            TestoSuggerimento.GetComponent<TextMeshProUGUI>().text = "Non hai abbasta monete";
            TestoSuggerimento.SetActive(true);
        }
    }
    
    public void SuggerimentoDue()
    {
        if (monetine >= 3){
            TestoSuggerimento.SetActive(true);
            PlayerPrefs.SetInt("monetine", PlayerPrefs.GetInt("monetine")-3);
        }
        else{
            TestoSuggerimento.GetComponent<TextMeshProUGUI>().text = "Non hai abbasta monete";
            TestoSuggerimento.SetActive(true);
        }
    }
    
    public void SuggerimentoTre()
    {
        if (monetine >= 4){
            TestoSuggerimento.SetActive(true);
            PlayerPrefs.SetInt("monetine", PlayerPrefs.GetInt("monetine")-4);
        }
        else{
            TestoSuggerimento.GetComponent<TextMeshProUGUI>().text = "Non hai abbasta monete";
            TestoSuggerimento.SetActive(true);
        }
    }

}
