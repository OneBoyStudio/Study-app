using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TestSceneEventController : MonoBehaviour
{

    public SerializeFiles listStorageObject;
    public GameObject Textbox;
    public data_handling data;
    public List<GameObject> buttons;
    static int target_number;
    int correct_count;
    public GameObject score;
    public int score_number = 0;

    public List<string> testlistfront;
    public List<string> testlistback;


    // Start is called before the first frame update
    void Start()
    {
        CreateTest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateTest()
    {
        //load target question
        int length = testlistback.Count;
        target_number = UnityEngine.Random.Range(0, length - 1);
        Debug.Log(target_number);

        // set textbox to target index front
        Textbox.GetComponent<TextMeshProUGUI>().text = data.front[target_number];

        //create a new back list to work with
        List<string> temp_back = new List<string>();
        temp_back = data.back;

        //create a random answer list to be added to buttons

        List<string> answer = new List<string>();
        answer.Add(data.back[target_number]);

        for (int i = 0; i < 2; i++)
        {
            int temp = UnityEngine.Random.Range(0, data.back.Count - 1);



            answer.Add(data.back[temp]);
            temp_back.RemoveAt(temp);
        }

        //Change button text

        for (int i = 0; i < 3; i++)
        {
            int temp = UnityEngine.Random.Range(0, answer.Count - 1);
            buttons[i].GetComponentInChildren< TextMeshProUGUI>().text = answer[temp];
            answer.RemoveAt(temp);
        }



    }

    public void Respond(int num)
    {
        string respond =  buttons[num].GetComponentInChildren<TextMeshProUGUI>().text;

        CreateTest();

        if (string.Equals(data.back[target_number], respond) == true){
            correct_count += 1;
            //you are correct
            score_number++;
        }
        else
        {
            score_number--;
        }

        score.GetComponent<TextMeshProUGUI>().text = score_number.ToString();
    }


    
}
