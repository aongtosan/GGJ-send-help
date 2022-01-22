using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public Button SFXButton;
    public Button optionsButton;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        SFXButton = root.Q<Button>("sfx-button");
        optionsButton = root.Q<Button>("options-button");

        SFXButton.clicked += SFXPressed;
        optionsButton.clicked += OptionsPressed;
    }

    void SFXPressed()
    {
        Debug.Log("SFX clicked");
    }

    void OptionsPressed()
    {
        Debug.Log("Options clicked");
    }
}
