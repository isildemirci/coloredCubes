using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScene : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("LevelIntro");
    }
    
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
}
