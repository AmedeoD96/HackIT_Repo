using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class HintsMenuVertical : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI suggerimento1;
    [SerializeField] private TextMeshProUGUI suggerimento2;
    [SerializeField] private GameManager _gameManager;
    public PasswordID currentPassword;
    private int monetine;
    private const string noMoney = "Non hai abbastanza monete";
    [SerializeField] private TextMeshProUGUI moneteDisponibili;
    private string moneteText;
    private const string txt = "Monete disponibili: ";
    public GameObject pulsanteSuggerimento1;
    public GameObject pulsanteSuggerimento2;

    // Start is called before the first frame update
    void Start()
    {
        monetine = PlayerPrefs.GetInt("monetine");
        
        suggerimento1.gameObject.SetActive(false);
        suggerimento2.gameObject.SetActive(false);
        currentPassword = _gameManager.currentPassword;
    }

    public void MostraSuggerimento1() {
        var passwordData = GestorePassword.intance.GetPasswordData(currentPassword);

        if (monetine >= passwordData.listaSuggerimenti[0].costo){
            suggerimento1.SetText(passwordData.listaSuggerimenti[0].suggerimentTxt);
            suggerimento1.gameObject.SetActive(true);
            monetine -= passwordData.listaSuggerimenti[0].costo;
            moneteText = monetine.ToString();
            moneteDisponibili.SetText(txt + moneteText);
            pulsanteSuggerimento1.SetActive(false);
        }
        else{
            suggerimento1.SetText(noMoney);
            suggerimento1.gameObject.SetActive(true);
        }
        
        PlayerPrefs.SetInt("monetine", monetine);
        PlayerPrefs.Save();
    }
    
    public void MostraSuggerimento2() {
        var passwordData = GestorePassword.intance.GetPasswordData(currentPassword);
        moneteDisponibili.SetText(txt + moneteText);

        if (monetine >= passwordData.listaSuggerimenti[1].costo){
            suggerimento2.SetText(passwordData.listaSuggerimenti[1].suggerimentTxt);
            suggerimento2.gameObject.SetActive(true);
            monetine -= passwordData.listaSuggerimenti[1].costo;
            moneteText = monetine.ToString();
            moneteDisponibili.SetText(txt + moneteText);
            pulsanteSuggerimento2.SetActive(false);
        }
        else{
            suggerimento2.SetText(noMoney);
            suggerimento2.gameObject.SetActive(true);
        }
        
        PlayerPrefs.SetInt("monetine", monetine);
        PlayerPrefs.Save();
    }
}
