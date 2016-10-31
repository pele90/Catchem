using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	#region Fields

	// amount of x movement
	private float _moveX = 0f;

	//movement movemenSpeed
	public float movementSpeed = 0f;

	#endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveX = Input.GetAxis("Horizontal");

	    _moveX *= 1.2f;
       
		GetComponent<Rigidbody2D>().velocity = new Vector2(_moveX * movementSpeed, Constants.instance.ZERO);
	}


}
