using UnityEngine;
using System.Collections;

public class WhiteFeather : MonoBehaviour
{
    #region Fields

    //value added to the player score
    public int itemValue;
    public float fallingSpeed;

    private float amplitude = 2f;
    private float t = 0f;

    #endregion

    #region Unity Methods

    // Use this for initialization
    void Start()
    {
        itemValue = Constants.instance.WHITE_FEATHER_ITEM_VALUE;
        fallingSpeed = Constants.instance.WHITE_FEATHER_ITEM_FALLING_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(amplitude * Mathf.Cos(t), fallingSpeed * Time.deltaTime);
        t += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //checks if item is colliding with player, if true destroy object and add item value to score
        if (coll.gameObject.tag == Constants.instance.PLAYER)
        {
            Destroy(gameObject);

            //add item value to player score
            GameManager.Score += itemValue;
        }

        // checks if item is colliding with floor, if true destroy item
        if (coll.gameObject.tag == Constants.instance.FLOOR)
        {
            Destroy(gameObject, 3);
        }

    }
    #endregion
}


