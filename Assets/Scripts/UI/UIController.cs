using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private Button SFXButton;
    private Button optionsButton;
    private Label timeLabel;
    private Label miceLabel;
    private Label hpLabel;
    private bool isPuased;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        SFXButton = root.Q<Button>("sfx-button");
        optionsButton = root.Q<Button>("options-button");
        timeLabel = root.Q<Label>("time-label");

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

    public void setTime(int time){
        timeLabel.text = formatTime(time);
    }

    private string formatTime(int time){
        string min = (time/60) < 10 ? ("0" + (time/60).ToString()) : (time/60).ToString();
        string sec = (time%60) < 10 ? ("0" + (time%60).ToString()) : (time%60).ToString();
        
        return $"{min}:{sec}";
    }

    void Update()
    {
        // Debug.Log(Time.time);
        setTime(Mathf.FloorToInt(Time.time));
    }
}
