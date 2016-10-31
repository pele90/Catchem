using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void LoadBegginingLevel()
    {
        GameManager.Score = 0;
        SceneManager.LoadScene("startLevel");
    }

    public void LoadAboutScreen()
    {
        SceneManager.LoadScene("aboutScreen");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
