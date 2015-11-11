using UnityEngine;

public class SkullItem : MonoBehaviour
{
	#region Fields

	//reference to rigidbody
	private Rigidbody2D rigidbody;

	//value added to the player score
	public int itemValue;

	public float fallingSpeed;

	private GameManager gameManager;

    #endregion

    #region Unity Methods

    // Use this for initialization
    void Start()
    {
	    gameManager = GameManager.instance;
		rigidbody = GetComponent<Rigidbody2D>();
		itemValue = Constants.instance.SKULL_ITEM_VALUE;
		fallingSpeed = Constants.instance.SKULL_ITEM_FALLING_SPEED;
	}

	// Update is called once per frame
	void Update()
	{
		rigidbody.velocity = new Vector2(Constants.instance.ZERO, -fallingSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//checks if item is colliding with player, if true destroy object and add item value to score
		if (coll.gameObject.tag == Constants.instance.PLAYER)
		{
				Destroy(gameObject);

			gameManager.PlayerLife--;
			gameManager.lives[--gameManager.CurrentHeart] = false;
			Debug.Log(gameManager.CurrentHeart);
		}

		// checks if item is colliding with floor, if true destroy item
		if (coll.gameObject.tag == Constants.instance.FLOOR)
		{
			Destroy(gameObject);
		}

	}

	#endregion
}
