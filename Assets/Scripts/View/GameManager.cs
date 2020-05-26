using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject letter;

    public GameObject correctText;

    public GameObject wrongText;

    public GameObject cen;

    public Transform canvas;

    private string wordToGuess = "";

    private int lengthOfWordToGuess;

    char[] lettersToGuess;

    bool[] lettersGuessed;

    int i = 0;

    String result = "";

    //public bool [] allWordsSelected;
    public String parola;

    int k = 0;
    
    readonly SortedList<int,char> dizionario = new SortedList<int, char>();

    [SerializeField] private string SceneName = "WordGame";

    private bool risultato;
    

    // Start is called before the first frame update
    void Start()
    {
        correctText = GameObject.Find("Correct");
        wrongText = GameObject.Find("Wrong");
        cen = GameObject.Find("CenterOfTheScreen");

        initGame();
        initLetters();
    }

    // Update is called once per frame
    void Update()
    {
        checkKeyboard();
       
    }

    void initGame() {
        correctText.SetActive(false);
        wrongText.SetActive(false);

        wordToGuess = "Elephant";
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper();
        lettersToGuess = new char[lengthOfWordToGuess];
        lettersGuessed = new bool[lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray();
    }

    void initLetters() 
    {
        for (int i = 0; i < lengthOfWordToGuess; i++) 
        {
            Vector3 newPosition;
            newPosition = new Vector3(cen.transform.position.x + ((i - lengthOfWordToGuess / 2.0f) * 100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate(letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(canvas);

            //allWordsSelected[i] = false;
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
            
            
            if (wrongText.activeSelf == true)
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
            int letterPressedAsInt = System.Convert.ToInt32(letterPressed);
            
            if (letterPressedAsInt >= 97 && letterPressed <= 122)  {
                if (i < lengthOfWordToGuess) {

                    letterPressed = System.Char.ToUpper(letterPressed);

                    GameObject.Find("letter" + (i+1)).GetComponent<TextMeshProUGUI>().text = letterPressed.ToString();
                    GameObject.Find("letter" + (i+1)).GetComponent<TextMeshProUGUI>().color = Color.white;
                    //allWordsSelected[i] = true;
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

                    //result += letterPressed.ToString();
                } 
                //if (i == lengthOfWordToGuess)  {

                    //for (int j = 0; j < lengthOfWordToGuess; j++)
                    //{
                     //   k = 0;
                      //  if (allWordsSelected[j] == true)
                       // {
                       //     k++;
                       // }
                    //}

                    if (k == lengthOfWordToGuess) //poi va k
                    {
                        //correctText.SetActive(true);
                        //for (i = 0; i < lengthOfWordToGuess; i++)
                        //{
                        //    parola = parola + result[i];
                        //}
                        foreach (var indexLetter in dizionario)
                        {
                            parola += indexLetter.Value;
                        }
                        //parola = result;
                        //Debug.Log(parola);
                        risultato = String.Equals(parola, wordToGuess);
                        if (risultato == true)  {
                            correctText.SetActive(true);
                        }
                        else  {
                            wrongText.SetActive(true);
                        }
                    }

                //}
                
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
                    //result = result.Remove(result.Length - 1);   
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
}
