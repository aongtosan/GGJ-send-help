using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private Button SFXButton;
    private Button optionsButton;
    private Button resumeButton;
    private Label timeLabel;
    private Label miceLabel;
    private Label hpLabel;
    private bool isPuased;
    private VisualElement pauseWindow;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        SFXButton = root.Q<Button>("sfx-button");
        optionsButton = root.Q<Button>("options-button");
        resumeButton = root.Q<Button>("resume-button");
        timeLabel = root.Q<Label>("time-label");
        pauseWindow = root.Q<VisualElement>("pause-window");

        SFXButton.clicked += SFXPressed;
        optionsButton.clicked += OptionsPressed;
        resumeButton.clicked += ResumePressed;
    }

    void SFXPressed()
    {
        Debug.Log("SFX clicked");
    }

    void OptionsPressed()
    {
        Debug.Log("Options clicked");
        pauseWindow.visible = true;
    }

    void ResumePressed()
    {
        pauseWindow.visible = false;
    }

    public void setTime(int time){
        timeLabel.text = formatTime(time);
    }

    public void setMice(int mice){
        miceLabel.text = mice.ToString();
    }

    public void setHP(int hp){
        hpLabel.text = hp.ToString();
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
