using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializeFiles : MonoBehaviour
{

    public GameObject listStorageObject;

    void Start()
    {
        loadPrior();
    }

    void Update()
    {

    }

    public void saveCurrentData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        saveData data = new saveData();

        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            file = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/save.txt");
        }

        data.cardFront = listStorageObject.GetComponent<data_handling>().front;
        data.cardBack = listStorageObject.GetComponent<data_handling>().back;
        data.Deck = listStorageObject.GetComponent<Flashcard_Addition>().Deck;

        bf.Serialize(file, data);
        file.Close();
    }

    public void loadPrior()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Open);
            saveData data = (saveData)bf.Deserialize(file);

            listStorageObject.GetComponent<data_handling>().front = data.cardFront;
            listStorageObject.GetComponent<data_handling>().back = data.cardBack;
            listStorageObject.GetComponent<data_handling>().Deck = data.Deck;

            file.Close();
        }
    }
}

[Serializable]
public class saveData
{
    public List<string> Deck = new List<string>();
    public List<string> cardFront = new List<string>();
    public List<string> cardBack = new List<string>();

    public saveData()
    {
        Deck = new List<string>();
        cardFront = new List<string>();
        cardBack = new List<string>();
    }
}