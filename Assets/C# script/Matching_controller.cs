using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEngine.UIElements;

public class MainCardMatchScript : MonoBehaviour
{

    public Button buttonPreFabFront;
    public Button buttonPreFabBack;
    public List<Button> cardFrontImage = new List<Button>();
    public List<Button> cardBackImage = new List<Button>();
    public List<Button> shuffledCards = new List<Button>();



    public SerializeFiles listStorageObject;
    public data_handling data;
    public List<GameObject> tiles;

    public Button selectBut1;
    public Button selectBut2;

    public List<string> selected_front;
    public List<string> selected_back;

    // Start is called before the first frame update
    void Start()
    {
        displayTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void displayTiles()
    {
        //choose 4 question&

        List<string> temp_front = new List<string>();
        temp_front = data.front;
        int length = temp_front.Count;

        for (int i = 0; i < tiles.Count; i++)
        {
            int target_number = UnityEngine.Random.Range(0, length - 1);
            selected_front.Add(data.front[target_number]);
            selected_back.Add(data.back[target_number]);
            temp_front.RemoveAt(target_number);

        }
    }

    public void displayCards(string[] cardFront, string[] cardBack)
    {
        // preFab = new Button;
        //prefab Instantiate(Button ParentButton);
        int[] xPos = new int[8];
        xPos[0] = 50;
        for (int i = 1; i < xPos.Length; i++)
        {
            xPos[i] = 50 + (100 + 5) * i;
        }

        int[] yPos = new int[3];
        yPos[0] = -95;
        for (int i = 1; i < yPos.Length; i++)
        {
            yPos[i] = -95 + (-100 - 5) * i;
        }

        for (int i = 0; i < cardFront.Length; i++)
        {
            float k = i;
            float q = Mathf.Floor(k / 8);
            Button newButton1 = (Button)Instantiate(buttonPreFabFront, new Vector2(k, q), Quaternion.identity);
            Button newButton2 = (Button)Instantiate(buttonPreFabBack, new Vector2(k, q), Quaternion.identity);
            cardFrontImage.Add(newButton1);
            cardBackImage.Add(newButton2);
        }

        //shuffle the cards

        shuffledCards.AddRange(cardBackImage);
        shuffledCards.AddRange(cardFrontImage);

        int num = cardFrontImage.Count;
        for (int i = 0; i < cardFrontImage.Count * 2; i++)
        {//choose a random Card of the deck and swap it with the Card at i
            int randomIndex = (int)(Random.Range(num * 2 - i - 1, i)/*Math.random()* (num*2-i-1)+ i*/); //subtract i from num to account for the number of cards already sorted; add i at the end to check the current position of the array onwards
            Button randomCard = shuffledCards[randomIndex];
            shuffledCards[randomIndex] = shuffledCards[i];
            shuffledCards[i] = randomCard;
        }
        for (int i = 0; i < shuffledCards.Count; i++)
        {
            float k = i;
            float q = Mathf.Floor(k / 8);
            changePos(shuffledCards[i], k, q);
            // Button newButton1 = (Button)Instantiate(buttonPreFabFront, new Vector2(k, q), Quaternion.identity);
            // Button newButton2 = (Button)Instantiate(buttonPreFabBack, new Vector2(k, q), Quaternion.identity);
            // cardFrontImage.Add(newButton1);
            // cardBackImage.Add(newButton2);
        }
    }


    //change the position of a card
    public void changePos(Button but, float xPos, float yPos)
    {
        but.transform.position = new Vector2(xPos, yPos);
        //return but;
    }

     void cardSelected(Button b1, Button b2)
    {
        selectBut1 = b1;
        selectBut2 = b2;

        //this removes the correctly chosen cards from the deck and from the screen - ERROR with extracting the button text as a string

        /*for (int i = 0; i < cardFrontImage.Count; i++){
            if (selectBut1.GetComponentInChildren<TextMeshProUGUI>().text.ToString() .equals(cardFrontImage[i]) && selectBut2.GetComponentInChildren<TMP_Text>().text.equals(cardBackImage[i])){
                Debug.Log (selectBut1 + " and " + selectBut2.GetComponentInChildren<TMP_Text>().text + " buttons were selected");
                for (int j = 0; j < shuffledCards.Count; j++){
                    if (shuffledCards[j].equals(selectBut1.GetComponentInChildren<TMP_Text>().text) ^ shuffledCards[j].equals(selectBut2.GetComponentInChildren<TMP_Text>().text)){
                        shuffledCards[j].gameObject.SetActive(false);
                    }
                }
                shuffledCards.Remove(selectBut1.GetComponentInChildren<TextMeshProUGUI>().text);
                shuffledCards.Remove(selectBut2.GetComponentInChildren<TMP_Text>().text);
                cardBackImage.Remove(selectBut1);
                cardFrontImage.Remove(selectBut1);
                cardBackImage.Remove(selectBut2);
                cardFrontImage.Remove(selectBut2);
            }
        }*/
    }

    public void Selectedcard(Button button)
    {
        if  (selectBut1 == null) {
            selectBut1 = button;
        }
        else if (selectBut2 == null)
        {
            selectBut2 = button;
        }
        else
        {
            cardSelected(selectBut1, selectBut2);
        }
    }

}
