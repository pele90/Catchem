using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GameManager : MonoBehaviour
{
	#region Fields
	static GameManager _instance;
	public Text scoreText;
    public Text pauseText;

    private int _score;
	private bool _paused;
	public int _numberOfItemsToFall;

	public string levelNameToLoadNext;

	#endregion

	#region Singleton

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

	#endregion

	#region Properties

	public int Score
	{
		get { return _score; }
		set { _score = value; }
	}

	public int NumberOfItemsToFall
	{
		get
		{
			return _numberOfItemsToFall;
		}
		set { _numberOfItemsToFall = value; }
	}

	public bool Paused
	{
		get { return _paused; }
		set { _paused = value; }
	}

	#endregion

	#region Unity methods

	void Start()
	{
		Paused = false;
		Score = 0;
	}

	void Update()
	{
        
		if (NumberOfItemsToFall <= 0)
		{
			try
			{
				Application.LoadLevel(levelNameToLoadNext);
			}
			catch (Exception e)
			{
                Debug.Log(e);
				Application.Quit();			
			}
			
		}

		scoreText.text = "Score: " + Score;

		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (Paused == false)
			{
				Paused = true;
				Time.timeScale = 0;
                pauseText.text = "Paused";
			}
			else
			{
				Paused = false;
				Time.timeScale = 1;
                pauseText.text = "";
            }
			
		}
	}

	#endregion
}
