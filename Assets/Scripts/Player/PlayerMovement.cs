using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	#region Fields

	// amount of x movement
	private float _moveX = 0f;

	//rigidbody reference
	private Rigidbody2D rigidbody2D;

	//movement movemenSpeed
	public float movementSpeed = 0f;

	#endregion

	// initialization method
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		_moveX = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(_moveX * movementSpeed, Constants.instance.ZERO);
	}


}
