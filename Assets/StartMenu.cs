using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject create_new;
    public GameObject start;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Flashcard_Addition_Scene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
