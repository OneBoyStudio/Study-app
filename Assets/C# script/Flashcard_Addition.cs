using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class Flashcard_Addition : MonoBehaviour
{
    public List<string> Flashcards_front = new List<string>();
    public List<string> Flashcards_back = new List<string>();

    public List<string> Deck = new List<string>();

    public GameObject listStorageObject;

    public GameObject front;
    public GameObject back;
    public GameObject deck;

    public TextMeshProUGUI fbtoggle;
    public TextMeshProUGUI faceIndicator;

    bool fileExists;

    void Start()
    {

    }

    public void addNote()
    {
        listStorageObject.GetComponent<data_handling>().front.Add(front.GetComponent<TMPro.TMP_InputField>().text);
        listStorageObject.GetComponent<data_handling>().back.Add(back.GetComponent<TMPro.TMP_InputField>().text);
        listStorageObject.GetComponent<data_handling>().Deck.Add(deck.GetComponent<TMPro.TMP_InputField>().text);

        Flashcards_front.Add(front.GetComponent<TMPro.TMP_InputField>().text);
        front.GetComponent<TMPro.TMP_InputField>().text = string.Empty;
        Flashcards_back.Add(back.GetComponent<TMPro.TMP_InputField>().text);
        back.GetComponent<TMPro.TMP_InputField>().text = string.Empty;

        Deck.Add(deck.GetComponent<TMPro.TMP_InputField>().text);
    }

    public void toggle_FrontBack()
    {
        front.SetActive(!front.activeSelf);
        back.SetActive(!back.activeSelf);

        if(front.activeSelf == true)
        {
            fbtoggle.GetComponent<TextMeshProUGUI>().text = "Back";
            faceIndicator.GetComponent<TextMeshProUGUI>().text = "Front";
        }
        else
        {
            fbtoggle.GetComponent<TextMeshProUGUI>().text = "Front";
            faceIndicator.GetComponent<TextMeshProUGUI>().text = "Back";
        }
    }
}