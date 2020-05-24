using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsMenuVertical : MonoBehaviour
{
    public GameObject TestoSuggerimento;


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
        TestoSuggerimento.SetActive(true);
    }

}
