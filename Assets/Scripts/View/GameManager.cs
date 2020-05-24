using System;
using System.Collections;
using System.Collections.Generic;
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

    String result;

    //public bool [] allWordsSelected;

    //public int k = 0;
    

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
        GameObject.Find("letter" + (i + 1)).GetComponent<Text>().color = Color.yellow;
        if (Input.anyKey)
        {

            if (wrongText.activeSelf == true)
            {
                SceneManager.LoadScene("WordGame");
            }
            char letterPressed = Input.inputString.ToCharArray(0,1)[0];
            int letterPressedAsInt = System.Convert.ToInt32(letterPressed);
            
            if (letterPressedAsInt >= 97 && letterPressed <= 122)  {
                if (i < lengthOfWordToGuess) {

                    letterPressed = System.Char.ToUpper(letterPressed);

                    GameObject.Find("letter" + (i+1)).GetComponent<Text>().text = letterPressed.ToString();
                    GameObject.Find("letter" + (i+1)).GetComponent<Text>().color = Color.white;
                    //allWordsSelected[i] = true;
                    i++;

                    result = result + letterPressed.ToString();
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

                    if (i == lengthOfWordToGuess) //poi va k
                    {
                        bool risultato = String.Equals(result, wordToGuess);
                        if (risultato == true)  {
                            correctText.SetActive(true);
                        }
                        else  {
                            wrongText.SetActive(true);
                        }
                    }

                //}
                
            } else if(letterPressedAsInt == 32)  {
                GameObject.Find("letter" + (i+1)).GetComponent<Text>().color = Color.white;
                i++;
                if(i >= lengthOfWordToGuess) {
                    i = i - lengthOfWordToGuess; 
                }
            } else if (letterPressedAsInt == 8)
            {
                GameObject.Find("letter" + (i+1)).GetComponent<Text>().color = Color.white;
                i--;
                result = result.Remove(result.Length - 1);
            }
        }
    }
}
