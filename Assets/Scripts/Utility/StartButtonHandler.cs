using UnityEngine;
using System.Collections;

public class StartButtonHandler : MonoBehaviour {

	public void LoadBegginingLevel () {
        Application.LoadLevel("basicSetup");
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
