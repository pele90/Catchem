using UnityEngine;

public class SkullItem : Item
{
    void Start()
    {
        itemValue = Constants.instance.SKULL_ITEM_VALUE;
        fallingSpeed = Constants.instance.SKULL_ITEM_FALLING_SPEED;
    }


    public new void OnCollisionEnter2D(Collision2D coll)
    {
        //checks if item is colliding with player, if true destroy object and add item value to score
        if (coll.gameObject.tag == Constants.instance.PLAYER)
        {
            Destroy(gameObject);

            GameManager.instance.PlayerLife--;
            GameManager.instance.lives[GameManager.instance.CurrentHeart--] = false;
        }

        // checks if item is colliding with floor, if true destroy item
        if (coll.gameObject.tag == Constants.instance.FLOOR)
        {
            Destroy(gameObject);
        }

    }
}
