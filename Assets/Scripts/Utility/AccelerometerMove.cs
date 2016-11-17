using UnityEngine;
using System.Collections;

public class AccelerometerMove : MonoBehaviour
{

    public float speed = 15;
    private float xAcc;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xAcc = Input.acceleration.x;
        if (xAcc > 0.05 || xAcc < -0.05)
        {
            Debug.Log(xAcc);
            GetComponent<Rigidbody>().velocity = new Vector3(xAcc * speed, 0f, 0f);
        }
        else
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

    }
}
