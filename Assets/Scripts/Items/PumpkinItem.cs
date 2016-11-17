using UnityEngine;

public class PumpkinItem : Item
{
	void Start()
	{
		itemValue = Constants.instance.PUMPKIN_ITEM_VALUE;
		fallingSpeed = Constants.instance.PUMPKIN_ITEM_FALLING_SPEED;
	}
}
