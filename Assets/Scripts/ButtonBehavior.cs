using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Test Scene");
    }
}
