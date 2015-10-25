using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour
{
	static Constants _instance;

	// Property for getting existing instance of GameManager or create new instance
	static public Constants instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(Constants)) as Constants;

				if (_instance == null)
				{
					GameObject go = new GameObject("Constants");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<Constants>();
				}
			}
			return _instance;
		}
	}

	#region Static Fields

	public int ZERO = 0;
	public int MILISECOND_MULTIPLIER = 1000;

	// starting position
	public float MIN_ITEM_STARTING_POINT = -6.0f;
	public float MAX_ITEM_STARTING_POINT = 6.0f;
	public float HEIGHT_ITEM_STARTING_POINT = 3.0f;

	// Gameobject strings
	public string PLAYER = "Player";
	public string FLOOR = "Floor";

	// Item values
	public int PUMPKIN_ITEM_VALUE = 10;
	public int SKULL_ITEM_VALUE = 20;
	public int WITCH_HAT_ITEM_VALUE = 30;
	public int RED_APPLE_ITEM_VALUE = 40;
	//public static int LIFE_HEART_ITEM_VALUE = 1;

	// Item falling speed
	public float PUMPKIN_ITEM_FALLING_SPEED = 1.5f;
	public float SKULL_ITEM_FALLING_SPEED = 2;
	public float WITCH_HAT_ITEM_FALLING_SPEED = 2.2f;
	public float RED_APPLE_ITEM_FALLING_SPEED = 2.5f;

	// Item falling frequency
	public int PUMPKIN_ITEM_FALLING_FREQUENCY = 3;
	public int SKULL_ITEM_FALLING_FREQUENCY = 8;
	public int RED_APPLE_ITEM_FALLING_FREQUENCY = 10;
	public int WITCH_HAT_ITEM_FALLING_FREQUENCY = 15;

	#endregion



}
