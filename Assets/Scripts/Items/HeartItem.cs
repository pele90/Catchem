using UnityEngine;
using System.Collections;

public class HeartItem : MonoBehaviour
{

    #region Fields

    public float fallingSpeed;

    #endregion

    #region Unity Methods

    // Use this for initialization
    void Start()
    {
        fallingSpeed = Constants.instance.LIFE_HEART_ITEM_FALLING_SPEED;
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(Constants.instance.ZERO, -fallingSpeed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //checks if item is colliding with player, if true destroy object and add item value to score
        if (coll.gameObject.tag == Constants.instance.PLAYER)
        {
            Destroy(gameObject);

            if (GameManager.instance.PlayerLife < 5)
                GameManager.instance.PlayerLife++;

            if (GameManager.instance.CurrentHeart < 4)
                GameManager.instance.lives[++GameManager.instance.CurrentHeart] = true;
        }

        // checks if item is colliding with floor, if true destroy item
        if (coll.gameObject.tag == Constants.instance.FLOOR)
        {
            Destroy(gameObject);
        }

    }
    #endregion
}
