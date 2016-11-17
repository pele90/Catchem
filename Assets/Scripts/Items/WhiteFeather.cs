using UnityEngine;
using System.Collections;

public class WhiteFeather : Item
{
    void Start()
    {
        itemValue = Constants.instance.WHITE_FEATHER_ITEM_VALUE;
        fallingSpeed = Constants.instance.WHITE_FEATHER_ITEM_FALLING_SPEED;
    }

    new void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(amplitude * Mathf.Cos(t), -fallingSpeed);
        t += Time.deltaTime;
    }

    
}


