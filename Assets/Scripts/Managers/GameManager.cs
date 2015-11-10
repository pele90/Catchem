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

    private static int _score;
	private bool _paused;
    private bool _slowed;
    private int _numberOfItemsToFall = 10;

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

	public static int Score
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

    public bool Slowed
    {
        get { return _slowed; }
        set { _slowed = value; }
    }

    #endregion

    #region Unity methods

    void Start()
	{
		Paused = false;
	}

	void Update()
	{
        // check if all item are created
        if (NumberOfItemsToFall <= 0)
        {
            // if so stop instanting items
            // and wait until all item gameobjects are destroyed in the scene
            if (GameObject.FindGameObjectsWithTag("FallingItem").Length == 0)
            {
                try
                {
                    // after that load next level
                    Application.LoadLevel(levelNameToLoadNext);
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                    Application.Quit();
                }
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
        else if (Input.GetKeyUp(KeyCode.F))
        {
            if (Slowed)
            {
                Time.timeScale = 0.5f;
                Slowed = false;
            }
            else
            {
                Time.timeScale = 1;
                Slowed = true;
            }
            
        }
	}

	#endregion
}
