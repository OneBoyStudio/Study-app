using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Flashcard_Addition : MonoBehaviour
{
    List<string> Flashcards = new List<string>();
    public GameObject Flashcard_input;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log(Flashcards);
        }
    }

    void addNote()
    {
        Flashcards.Add(Flashcard_input.GetComponent<TMPro.TextMeshProUGUI>().text);
    }
}
