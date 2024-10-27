using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class togglecontroller : MonoBehaviour
{

    public Button toggle;


    public Sprite toggle_backside;
    public Sprite toggle_frontside;

    public GameObject Card_Back;
    public GameObject Card_Back_textbox;

    public GameObject Card_Front;
    public GameObject Card_Front_textbox;

    public GameObject indicator;


    public void ToggleBackToFront()
    {
       if (toggle.GetComponent<Image>().sprite == toggle_backside){
            toggle.GetComponent<Image>().sprite = toggle_frontside ;
            Card_Front.SetActive(false);
            Card_Front_textbox.SetActive(false);
            Card_Back.SetActive(true);
            Card_Back_textbox.SetActive(true);
            indicator.GetComponent<TextMeshProUGUI>().text = "Back";

        }
        else
        {
            toggle.GetComponent<Image>().sprite = toggle_backside;
            Card_Front.SetActive(true);
            Card_Front_textbox.SetActive(true);
            Card_Back.SetActive(false);
            Card_Back_textbox.SetActive(false);
            indicator.GetComponent<TextMeshProUGUI>().text = "Front";

        }


    }


}
