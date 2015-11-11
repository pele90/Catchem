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

	public int playerLife = 3;

	public bool[] lives;

	public Image[] images;

	private int currentHeart = 2;

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

	public int PlayerLife
	{
		get
		{
			return playerLife;
		}
		set { playerLife = value; }
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

	public int CurrentHeart
	{
		get { return currentHeart; }
		set { currentHeart = value; }
	}

	#endregion

    #region Unity methods

    void Start()
	{
		lives = new []{ true, true, true, false, false};
		Paused = false;
	}

	void Update()
	{
        // check if player has no lives
        if (PlayerLife < 0)
        {
            Application.LoadLevel("endGame");
        }

		for (int i = 0; i < lives.Length; i++)
		{
			if (lives[i])
			{
				images[i].enabled = true;
			}
			else
			{
				images[i].enabled = false;
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
