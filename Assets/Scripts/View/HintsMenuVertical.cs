using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsMenuVertical : MonoBehaviour
{
    public GameObject TestoSuggerimento;
    private int monetine = PlayerPrefs.GetInt("monetine");


    // Start is called before the first frame update
    void Start()
    {
        TestoSuggerimento.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TaskOnClick()
    {
        if (monetine == 2){
            TestoSuggerimento.SetActive(true);
            PlayerPrefs.SetInt("monetine", PlayerPrefs.GetInt("monetine")-2);
        }
        else{
            TestoSuggerimento.GetComponent<TextMeshProUGUI>().text = "Non hai abbasta monete";
            TestoSuggerimento.SetActive(true);
        }
        
    }

}
