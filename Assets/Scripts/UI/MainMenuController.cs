using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private Button startButton;
    private Button quitButton;
    // Start is called before the first frame update
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("start-button");
        quitButton = root.Q<Button>("quit-button");
       
        startButton.clicked += StartPressed;
        quitButton.clicked += QuitPressed;
    }


    void StartPressed()
    {
        SceneManager.LoadScene("Test Scene");
    }

    void QuitPressed()
    {
        Application.Quit();
    }
}
