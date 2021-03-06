﻿using UnityEngine;
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

    //public int TOTAL_NUMBER_OF_ITEMS = 3;


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
	public int HEALTH_POTION_ITEM_VALUE = 30;
	public int RED_APPLE_ITEM_VALUE = 40;
    public int WHITE_FEATHER_ITEM_VALUE = 50;

    // Item falling speed
    public float PUMPKIN_ITEM_FALLING_SPEED = 1.5f;
	public float SKULL_ITEM_FALLING_SPEED = 2;
	public float RED_APPLE_ITEM_FALLING_SPEED = 2.5f;
    public float LIFE_HEART_ITEM_FALLING_SPEED = 1.8f;
    public float WHITE_FEATHER_ITEM_FALLING_SPEED = 0.5f;

    // Item falling frequency
    public int PUMPKIN_ITEM_FALLING_FREQUENCY = 3;
	public int SKULL_ITEM_FALLING_FREQUENCY = 8;
	public int RED_APPLE_ITEM_FALLING_FREQUENCY = 10;
	public int LIFE_HEART_ITEM_FALLING_FREQUENCY = 20;

	// proggression counters
	public int FIRST_THRESHOLD = 100;
	public int SECOND_THRESHOLD = 300;
	public int THIRD_THRESHOLD = 600;

	// wait time for item to spawn
	public int MIN_WAIT_TIME = 1;
	public int MAX_WAIT_TIME = 30;
	public int EASY_MIN_WAIT_TIME = 20;
	public int HARD_MIN_WAIT_TIME = 10;
	public int EASY_MAX_WAIT_TIME = 30;
	public int HARD_MAX_WAIT_TIME = 20;

	#endregion



}
