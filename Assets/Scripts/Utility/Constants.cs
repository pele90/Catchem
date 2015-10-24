using UnityEngine;
using System.Collections;

public static class Constants
{
	public static int ZERO = 0;
	public static int MILISECOND_MULTIPLIER = 1000;

	// starting position
	public static int MIN_ITEM_STARTING_POINT = -6;
	public static int MAX_ITEM_STARTING_POINT = 6;
	public static int HEIGHT_ITEM_STARTING_POINT = 3;

	// Gameobject strings
	public static string PLAYER = "Player";
	public static string FLOOR = "Floor";

	// Item values
	public static int PUMPKIN_ITEM_VALUE = 10;
	public static int SKULL_ITEM_VALUE = 20;
	public static int WITCH_HAT_ITEM_VALUE = 30;
	public static int RED_APPLE_ITEM_VALUE = 40;
	//public static int LIFE_HEART_ITEM_VALUE = 1;

	// Item falling speed
	public static float PUMPKIN_ITEM_FALLING_SPEED = 1.5f;
	public static float SKULL_ITEM_FALLING_SPEED = 2;
	public static float WITCH_HAT_ITEM_FALLING_SPEED = 2.2f;
	public static float RED_APPLE_ITEM_FALLING_SPEED = 2.5f;

	// Item falling frequency
	public static int PUMPKIN_ITEM_FALLING_FREQUENCY = 3;
	public static int SKULL_ITEM_FALLING_FREQUENCY = 8;
	public static int RED_APPLE_ITEM_FALLING_FREQUENCY = 10;
	public static int WITCH_HAT_ITEM_FALLING_FREQUENCY = 15;

}
