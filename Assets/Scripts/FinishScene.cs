using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishScene : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
}
