using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsMenuVertical : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI suggerimento1;
    [SerializeField] private TextMeshProUGUI suggerimento2;
    [SerializeField] private GameManager _gameManager;
    private int monetine;

    // Start is called before the first frame update
    void Start()
    {
        monetine = PlayerPrefs.GetInt("monetine");
        
        suggerimento1.gameObject.SetActive(false);
        suggerimento2.gameObject.SetActive(false);
    }

    public void ShowPrimoSuggerimento() {
        if(monetine >= 2){
            switch (_gameManager.currentPassword){
                case PasswordID.Password1:
                    suggerimento1.SetText("La password è una combinazione degli indizi che hai trovato");
                    suggerimento1.gameObject.SetActive(true);
                    break;
                case PasswordID.Password2:
                    suggerimento1.SetText(
                        "I siti visitati ci parlano delle abitudini e delle passioni della persona. Di solito si tratta di elementi che l'utente è in grado di ricordare facilmente");
                    suggerimento1.gameObject.SetActive(true);
                    break;
                case PasswordID.Password3:
                    suggerimento1.SetText("Prendi le prime due parole di ogni indizio e usale");
                    suggerimento1.gameObject.SetActive(true);
                    break;
                case PasswordID.Password4:
                    suggerimento1.SetText("A volte alcune informazioni possono essere fuorvianti.");
                    suggerimento1.gameObject.SetActive(true);
                    break;
                case PasswordID.Password5:
                    suggerimento1.SetText("Non so che mettere");
                    suggerimento1.gameObject.SetActive(true);
                    break;
            }
            PlayerPrefs.SetInt("monetine", monetine-2);
        }
        else{
            suggerimento1.SetText("Non hai abbastanza monete per visualizzare il suggerimento");
            suggerimento1.gameObject.SetActive(true);
        }
    }
    
    public void ShowSecondoSuggerimento() {
        if(monetine >= 5){
            switch (_gameManager.currentPassword){
                case PasswordID.Password1:
                    suggerimento2.SetText("Le prime due lettere della password sono 'C' e 'I' e le ultime due sono '6' e '4'");
                    suggerimento2.gameObject.SetActive(true);
                    break;
                case PasswordID.Password2:
                    suggerimento2.SetText(
                        "Prima lettera della password 'G'. Settima lettera della password 'S'. Ultimo carattere '8'");
                    suggerimento2.gameObject.SetActive(true);
                    break;
                case PasswordID.Password3:
                    suggerimento2.SetText("Prima lettera della password 'Z'. Quarta lettera 'N'. Ultima lettera 'A'");
                    suggerimento2.gameObject.SetActive(true);
                    break;
                case PasswordID.Password4:
                    suggerimento2.SetText("BOH.");
                    suggerimento2.gameObject.SetActive(true);
                    break;
                case PasswordID.Password5:
                    suggerimento2.SetText("BOH");
                    suggerimento2.gameObject.SetActive(true);
                    break;
            }
            PlayerPrefs.SetInt("monetine", monetine-5);
        }
        else{
            suggerimento2.SetText("Non hai abbastanza monete per visualizzare il suggerimento");
            suggerimento2.gameObject.SetActive(true);
        }
    }
}
