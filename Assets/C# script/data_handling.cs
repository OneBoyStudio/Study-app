using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_handling : MonoBehaviour
{
    public List<string> front = new List<string>();
    public List<string> back = new List<string>();

    public List<string> Deck = new List<string>();
    void updateStorage(GameObject updater)
    {
        front = updater.GetComponent<Flashcard_Addition>().Flashcards_front;
        back = updater.GetComponent<Flashcard_Addition>().Flashcards_back;
        Deck = updater.GetComponent<Flashcard_Addition>().Deck;
    }
}
