using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    private float hInput = 0;

    //movement movemenSpeed
    public float movementSpeed = 0f;

    public float jumpSpeed = 5f;

    private Transform groundCheck;
    public LayerMask GroundLayer;

    #endregion

    void Start()
    {
        groundCheck = GetComponent<Transform>().FindChild("GroundCheck");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
        if (Input.GetButton("joystick button 0") || Input.GetButton("Jump"))
        {
            Jump();
        }

        Move(Input.GetAxis("Horizontal"));
#else
        Move(hInput);
#endif
    }

    public void Move(float p_moveX)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(p_moveX * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void Jump()
    {
        bool isGrounded = Physics2D.OverlapPoint(groundCheck.position, GroundLayer);

        if (isGrounded)
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    public void StartMoving(float p_moveX)
    {
        hInput = p_moveX;
    }
}
