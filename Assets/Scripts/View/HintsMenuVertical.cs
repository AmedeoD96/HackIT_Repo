using TMPro;
using UnityEngine;

public class HintsMenuVertical : MonoBehaviour
{
    [SerializeField] private GameObject TestoSuggerimento;
    [SerializeField] private GameObject suggerimento2;
    [SerializeField] private GameObject suggerimento3;
    private int monetine;
    
    // Start is called before the first frame update
    void Start()
    {
        monetine = PlayerPrefs.GetInt("monetine");
        TestoSuggerimento.SetActive(false);
        
        suggerimento2.SetActive(false);
        
        suggerimento3.SetActive(false);
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
            suggerimento2.SetActive(true);
            PlayerPrefs.SetInt("monetine", PlayerPrefs.GetInt("monetine")-5);
        }
        else{
            suggerimento2.GetComponent<TextMeshProUGUI>().text = "Non hai abbasta monete";
            suggerimento2.SetActive(true);
        }
    }
    
    public void SuggerimentoTre()
    {
        if (monetine >= 4){
            suggerimento3.SetActive(true);
            PlayerPrefs.SetInt("monetine", PlayerPrefs.GetInt("monetine")-4);
        }
        else{
            suggerimento3.GetComponent<TextMeshProUGUI>().text = "Non hai abbasta monete";
            suggerimento3.SetActive(true);
        }
    }

}
