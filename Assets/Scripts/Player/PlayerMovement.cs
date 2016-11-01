using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    // amount of x movement
    private float _moveX = 0f;

    //movement movemenSpeed
    public float movementSpeed = 0f;

    public float jumpSpeed = 0.1f;

    private Transform groundCheck;
    public LayerMask GroundLayer;

    private bool isJumping = false;
    #endregion

    void Start()
    {
        groundCheck = GetComponent<Transform>().FindChild("GroundCheck");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.L))
        {
            bool isGrounded = Physics2D.OverlapPoint(groundCheck.position, GroundLayer);

            if (isGrounded)
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        _moveX = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(_moveX * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
