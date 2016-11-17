using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected int itemValue;

    [SerializeField]
    protected float fallingSpeed;

    [SerializeField]
    protected float amplitude;

    [SerializeField]
    protected float t;

    protected void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Constants.instance.ZERO, -fallingSpeed);
    }

    protected void OnCollisionEnter2D(Collision2D coll)
    {
        //checks if item is colliding with player, if true destroy object and add item value to score
        if (coll.gameObject.tag == Constants.instance.PLAYER)
        {
            Destroy(gameObject);
            GameManager.Score += itemValue;
        }

        // checks if item is colliding with floor, if true destroy item
        if (coll.gameObject.tag == Constants.instance.FLOOR)
            Destroy(gameObject);

    }
}
