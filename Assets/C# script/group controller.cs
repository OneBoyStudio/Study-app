using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupcontroller : MonoBehaviour
{
    public GameObject startscreen;
    public GameObject CardCreation;
    public GameObject Decks;
    public GameObject Quiz;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToStartScreen()
    {
        startscreen.SetActive(true);
        CardCreation.SetActive(false);
        Decks.SetActive(false);
        Quiz.SetActive(false);
    }

    public void ToCardCreation()
    {
        startscreen.SetActive(false);
        CardCreation.SetActive(true);
        Decks.SetActive(false);
        Quiz.SetActive(false);
    }

    public void ToDecks()
    {
        startscreen.SetActive(false);
        CardCreation.SetActive(false);
        Decks.SetActive(true);
        Quiz.SetActive(false);
    }

    public void ToQuiz()
    {
        startscreen.SetActive(false);
        CardCreation.SetActive(false);
        Decks.SetActive(false);
        Quiz.SetActive(true);
    }

}
