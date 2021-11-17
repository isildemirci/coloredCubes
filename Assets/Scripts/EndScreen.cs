using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NextLevelButton()
    {
        LoadNextLevel();
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
