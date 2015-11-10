using UnityEngine;

public class ButtonHandler : MonoBehaviour {

	public void LoadBegginingLevel () {
        Application.LoadLevel("startLevel");
	}

    public void LoadAboutScreen()
    {
        Application.LoadLevel("aboutScreen");
    }

    public void LoadMainMenu()
    {
        Application.LoadLevel("mainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
