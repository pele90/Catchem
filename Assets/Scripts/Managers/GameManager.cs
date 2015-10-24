using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	static GameManager _instance;

	private int score = 0;
	public Text text;

	static public bool isActive
	{
		get
		{
			return _instance != null;
		}
	}

	// Property for getting existing instance of GameManager or create new instance
	static public GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;

				if (_instance == null)
				{
					GameObject go = new GameObject("GameManager");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<GameManager>();
				}
			}
			return _instance;
		}
	}

	public int Score
	{
		get { return score; }
		set { score = value; }
	}

	void Update()
	{
		text.text = "Ana's score: " + Score;
	}
}
