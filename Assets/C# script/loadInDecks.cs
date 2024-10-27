using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadInDecks : MonoBehaviour
{
    public GameObject deckPrefab;
    public GameObject data_import;
    public groupcontroller groupcontroller;
    public GameObject content;

    public List<string> Decks;
    public List<string> uniqueDecks;

    void Start()
    {
        loadDecks();
        Debug.Log("test");
    }

    public void loadDecks()
    {
        Decks = data_import.GetComponent<data_handling>().Deck;
        bool deckHasBeenAdded = false;

        foreach (string s in Decks)
        {
            foreach (string t in uniqueDecks)
            {
                if (s != t)
                {
                    deckHasBeenAdded = false;
                }
                else
                {
                    deckHasBeenAdded = true; break;
                }
            }

            if (deckHasBeenAdded == false)
            {
                uniqueDecks.Add(s);
            }
        }
    }

    public void instantiateDecks()
    {
        foreach(string s in uniqueDecks)
        {
            GameObject deckinstance = Instantiate(deckPrefab,content.transform);
            deckinstance.GetComponentInChildren<TextMeshProUGUI>().text = s;
            //deckinstance.GetComponentInChildren<Button>().onClick.AddListener(groupcontroller.ToQuiz);
            //DateTime.Now
        }
    }
}
