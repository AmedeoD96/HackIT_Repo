using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject letter;
    private GameObject correctText;
    private GameObject wrongText;
    private GameObject cen;
    private Transform canvas;
    private string wordToGuess = "";
    private Dictionary<string, string> passwords;
    private int lengthOfWordToGuess;
    char[] lettersToGuess;
    bool[] lettersGuessed;
    int i = 0;
    String result = "";
    public String parola;
    int k = 0;
    readonly SortedList<int,char> dizionario = new SortedList<int, char>();
    [SerializeField] private string SceneName = "WordGame";
    private bool risultato;
    private GameObject playerImg;
    private GameObject baloonImg;
    private Animator anim;
    private Animator baloonAnim;
    [SerializeField] private TextMeshProUGUI spiegazione;
    private GameObject btnAvanti;
    [SerializeField] private string newLevel;
    private GameObject retryButton;
    public PasswordID currentPassword;
    [SerializeField] private List<TextMeshProUGUI> listaIndizi = new List<TextMeshProUGUI>();
    private const string indizio = "Indizio [x]: ";

    // Start is called before the first frame update
    void Start() {
        correctText = GameObject.Find("Correct");
        wrongText = GameObject.Find("Wrong");
        cen = GameObject.Find("CenterOfTheScreen");
        playerImg = GameObject.Find("Player");
        baloonImg = GameObject.Find("Baloon");
        retryButton = GameObject.Find("Riprova");
        anim = playerImg.GetComponent<Animator>();
        baloonAnim = baloonImg.GetComponent<Animator>();
        playerImg.SetActive(false);
        baloonImg.SetActive(false);
        spiegazione.gameObject.SetActive(false);
        retryButton.SetActive(true);
        btnAvanti = GameObject.Find("Passa al livello successivo");
        btnAvanti.SetActive(false);
        passwords = new Dictionary<string, string>();

        currentPassword = GestorePassword.intance.GetUnusedPasswordId();
        var passwordData = GestorePassword.intance.GetPasswordData(currentPassword);
        int i = 0;

        spiegazione.SetText(passwordData.spiegazione);

        for (i = 0; i < passwordData.indizi.Count; i++){
            listaIndizi[i].gameObject.SetActive(true);
            listaIndizi[i].SetText(indizio.Replace("[x]", (i+1).ToString()) + passwordData.indizi[i]);
        }

        if (listaIndizi.Count >= i + 1){
            for (int k=i; k < listaIndizi.Count; k++){
                listaIndizi[k].gameObject.SetActive(false);
            }
        }

        initGame();
        initLetters();
    }

    // Update is called once per frame
    void Update() {
        checkKeyboard();
    }

    void initGame() {
        correctText.SetActive(false);
        wrongText.SetActive(false);

        wordToGuess = GestorePassword.intance.GetPasswordData(currentPassword).password;
        
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper();
        lettersToGuess = new char[lengthOfWordToGuess];
        lettersGuessed = new bool[lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray();
    }

    void initLetters() {
        for (int i = 0; i < lengthOfWordToGuess; i++) {
            Vector3 newPosition;
            newPosition = new Vector3(cen.transform.position.x + ((i - lengthOfWordToGuess / 2.0f) * 100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = Instantiate(letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(canvas);
        }
    } 


    void checkKeyboard()
    {
        var letter = GameObject.Find("letter" + (i + 1));
        if (letter == null)
        {
            return;
        }
        var letterText = letter.GetComponent<TextMeshProUGUI>();
        letterText.color = Color.yellow;
        if (Input.anyKey)
        {
            
            
            if (wrongText.activeSelf)
            {
                SceneManager.LoadScene(SceneName);
            }

            var InputString = Input.inputString;
            if (InputString.Length <= 0)
            {
                return;
            }
            
            var letters = InputString.ToCharArray(0, 1);
            
            char letterPressed = letters[0];
            int letterPressedAsInt = Convert.ToInt32(letterPressed);
            
            if ((letterPressedAsInt >= 97 && letterPressed <= 122) || (letterPressedAsInt >= 46 && letterPressed <= 57)) {
                if (i < lengthOfWordToGuess) {

                    letterPressed = Char.ToUpper(letterPressed);

                    GameObject.Find("letter" + (i+1)).GetComponent<TextMeshProUGUI>().text = letterPressed.ToString();
                    GameObject.Find("letter" + (i+1)).GetComponent<TextMeshProUGUI>().color = Color.white;
                    if (dizionario.ContainsKey(i))
                    {
                        dizionario.Remove(i);
                    }
                    else
                    {
                        k++;
                    }
                    dizionario.Add(i, letterPressed);
                    i++;
                    if (k != lengthOfWordToGuess && i== lengthOfWordToGuess)
                    {
                        i = i - lengthOfWordToGuess;
                    }
                }

                if (k == lengthOfWordToGuess) { //Poi va a k
                        foreach (var indexLetter in dizionario) {
                            parola += indexLetter.Value;
                        }
                        
                        risultato = String.Equals(parola, wordToGuess);
                        if (risultato == true)  {
                            correctText.SetActive(true);
                            playerImg.SetActive(true);
                            anim.Play("PlayerReveal");
                            baloonAnim.Play("BaloonReveal");
                            baloonImg.SetActive(true);
                            
                            spiegazione.gameObject.SetActive(true);
                            
                            btnAvanti.SetActive(true);
                            retryButton.SetActive(false);
                        }
                        else  {
                            wrongText.SetActive(true);
                        }
                }

            } else if(letterPressedAsInt == 32)  {
                GameObject.Find("letter" + (i+1)).GetComponent<TextMeshProUGUI>().color = Color.white;
                i++;
                if(i >= lengthOfWordToGuess) {
                    i = i - lengthOfWordToGuess; 
                }
            } else if (letterPressedAsInt == 8)
            {
                if (i != 0)
                {
                    GameObject.Find("letter" + (i+1)).GetComponent<TextMeshProUGUI>().color = Color.white;
                    i--;
                }
            }
        }
    }

    public void retry()
    {
        for (int i = 0; i < lengthOfWordToGuess; i++)
        {
            Destroy( GameObject.Find("letter" + (i+1)));
        }

        i = 0;
        k = 0;
        initGame();
        initLetters();
        dizionario.Clear();
        parola = "";
        risultato = false;
    }

    public void NextLevel() {
        SceneManager.LoadScene(newLevel);
    }
}