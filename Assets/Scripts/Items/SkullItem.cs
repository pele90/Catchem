﻿using UnityEngine;

public class SkullItem : MonoBehaviour
{
	#region Fields

	//reference to rigidbody
	private Rigidbody2D rigidbody;

	//value added to the player score
	public int itemValue;

	public float fallingSpeed;

	#endregion

	#region Unity Methods

	// Use this for initialization
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		itemValue = Constants.instance.SKULL_ITEM_VALUE;
		fallingSpeed = Constants.instance.SKULL_ITEM_FALLING_SPEED;
	}

	// Update is called once per frame
	void Update()
	{
		rigidbody.velocity = new Vector2(Constants.instance.ZERO, -fallingSpeed);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//checks if item is colliding with player, if true destroy object and add item value to score
		if (coll.gameObject.tag == Constants.instance.PLAYER)
		{
			Destroy(gameObject);

			//add item value to player score
			GameManager.instance.Score += itemValue;
		}

		// checks if item is colliding with floor, if true destroy item
		if (coll.gameObject.tag == Constants.instance.FLOOR)
		{
			Destroy(gameObject);
		}

	}

	#endregion
}