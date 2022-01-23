using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Button SFXMuteButton;
    private Button SFXUnmuteButton;
    private Button optionsButton;
    private Button startButton;
    private Button resumeButton;
    private Button restartButton;
    private Button quitButton;
    private Label timeLabel;
    private Label miceLabel;
    private Label pauseLabel;
    private VisualElement pauseWindow;
    private bool isMuted;
    // Start is called before the first frame update
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        SFXMuteButton = root.Q<Button>("sfx-button-mute");
        SFXUnmuteButton = root.Q<Button>("sfx-button-unmute");
        optionsButton = root.Q<Button>("options-button");
        resumeButton = root.Q<Button>("resume-button");
        restartButton = root.Q<Button>("restart-button");
        startButton = root.Q<Button>("start-button");
        quitButton = root.Q<Button>("quit-button");
        timeLabel = root.Q<Label>("time-label");
        pauseLabel = root.Q<Label>("pause-label");
        miceLabel = root.Q<Label>("mice-label");
        pauseWindow = root.Q<VisualElement>("pause-window");

        SFXUnmuteButton.clicked += SFXPressed;
        SFXMuteButton.clicked += SFXPressed;
        optionsButton.clicked += OptionsPressed;
        startButton.clicked += StartPressed;
        resumeButton.clicked += ResumePressed;
        restartButton.clicked += RestartPressed;
        quitButton.clicked += QuitPressed;
    }

    void SFXPressed()
    {
        if(isMuted){
            isMuted = false;
            SFXUnmuteButton.style.display = DisplayStyle.Flex;
            SFXMuteButton.style.display = DisplayStyle.None;
        }
        else{
            isMuted = true;
            SFXUnmuteButton.style.display = DisplayStyle.None;
            SFXMuteButton.style.display = DisplayStyle.Flex;
        }
        Debug.Log("SFX clicked");
    }

    void StartPressed()
    {
        SceneManager.LoadScene("Test Scene");
    }

    void QuitPressed()
    {
        Application.Quit();
    }
    void OptionsPressed()
    {
        pauseWindow.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
    }

    void ResumePressed()
    {
        pauseWindow.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
    }

    void RestartPressed()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void setTime(int time){
        timeLabel.text = formatTime(time);
    }

    public void setMice(int mice){
        miceLabel.text = mice.ToString();
    }

    private string formatTime(int time){
        string min = (time/60) < 10 ? ("0" + (time/60).ToString()) : (time/60).ToString();
        string sec = (time%60) < 10 ? ("0" + (time%60).ToString()) : (time%60).ToString();
        
        return $"{min}:{sec}";
    }

    public void gameOver(){
        pauseWindow.style.display = DisplayStyle.Flex;
        pauseLabel.text = "Game Over!!!";
        pauseLabel.style.color = new StyleColor(Color.red);
        restartButton.style.display = DisplayStyle.Flex;
        resumeButton.style.display = DisplayStyle.None;
    }

    void Update()
    {
        // Debug.Log(Time.time);
        setTime(Mathf.FloorToInt(Time.time));
    }
}
