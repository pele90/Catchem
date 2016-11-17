using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_BLACKBERRY || UNITY_WINRT
    private float hInput = 0;
#endif

    private float movementSpeed = 15f;

    // Update is called once per frame
    void FixedUpdate()
    {

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT

        Move(Input.GetAxis("Horizontal"));
#else
        hInput = Input.acceleration.x;
        if (hInput > 0.01f || hInput < -0.01f)
            Move(hInput);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
#endif
    }

    public void Move(float p_moveX)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(p_moveX * movementSpeed, 0f);
    }
}
