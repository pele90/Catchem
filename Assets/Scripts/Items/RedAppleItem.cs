﻿using UnityEngine;

public class RedAppleItem : MonoBehaviour
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
		itemValue = Constants.RED_APPLE_ITEM_VALUE;
		fallingSpeed = Constants.RED_APPLE_ITEM_FALLING_SPEED;
	}

	// Update is called once per frame
	void Update()
	{
		rigidbody.velocity = new Vector2(Constants.ZERO, -fallingSpeed);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//checks if item is colliding with player, if true destroy object and add item value to score
		if (coll.gameObject.tag == Constants.PLAYER)
		{
			Destroy(gameObject);

			//add item value to player score
			GameManager.instance.Score += itemValue;
		}

		// checks if item is colliding with floor, if true destroy item
		if (coll.gameObject.tag == Constants.FLOOR)
		{
			Destroy(gameObject);
		}

	}

	#endregion
}
