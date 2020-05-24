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

    int i = 1;

    String result;

    //public Color altColor = Color.black;
    //public Renderer rend = GetComponent<Renderer>();


    // Start is called before the first frame update
    void Start()
    {
        correctText = GameObject.Find("Correct");
        wrongText = GameObject.Find("Wrong");
        cen = GameObject.Find("CenterOfTheScreen");

        //rend.material.color = altColor;

        initGame();
        initLetters();
    }

    // Update is called once per frame
    void Update()
    {
        checkKeyboard();
    }

    void initGame()

    {
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
        //int nbletters = lengthOfWordToGuess;
        for (int i = 0; i < lengthOfWordToGuess; i++)
        {
            Vector3 newPosition;
            newPosition = new Vector3(cen.transform.position.x + ((i - lengthOfWordToGuess / 2.0f) * 100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate(letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(canvas);
}
    }


    void checkKeyboard()
    {
        if (Input.anyKey)
        {

            if (wrongText.activeSelf == true)
            {
                SceneManager.LoadScene("WordGame");
            }
            char letterPressed = Input.inputString.ToCharArray(0,1)[0];
            int letterPressedAsInt = System.Convert.ToInt32(letterPressed);
            //altColor.r = 255f;
            //altColor.g = 255f;
            //altColor.b = 255f;
            //GameObject.Renderer.Material.Color = altcolor;
            if (letterPressedAsInt >= 97 && letterPressed <= 122)
            {
                if (i == lengthOfWordToGuess)
                {
                    bool risultato = String.Equals(result, wordToGuess);
                    if (risultato == true)
                    {
                        correctText.SetActive(true);
                    }
                    else
                    {
                        wrongText.SetActive(true);
                    }
                }
                if (i < lengthOfWordToGuess)
                {
                    letterPressed = System.Char.ToUpper(letterPressed);
                    GameObject.Find("letter" + (i)).GetComponent<Text>().text = letterPressed.ToString();
                    i++;
                    //gameObject.Renderer.Material.Color = Color.green;


                    result = result + letterPressed.ToString();
                }
            } else if(letterPressedAsInt == 32)
            {
                i++;
                if(i >= lengthOfWordToGuess)
                {
                    i = i - lengthOfWordToGuess; 
                }
                
            }
        }
    }
}
