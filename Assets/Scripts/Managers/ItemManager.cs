using System.Timers;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

	#region Fields

	//references to falling item
	public GameObject pumpkinItem;
	public GameObject skullItem;
	public GameObject witchHatItem;
	public GameObject redAppleItem;
	#endregion

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SpawnPumpkin", 1, 2);
		InvokeRepeating("SpawnSkull", 3, 3);
		InvokeRepeating("SpawnWitchHat", 5, 5);
		InvokeRepeating("SpawnRedApple", 10, 10);
	}

	// Update is called once per frame
	void Update()
	{
	
	}

	#region Methods
	
	void SpawnPumpkin()
	{
		Instantiate(pumpkinItem , new Vector3(Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT)
					, Constants.instance.HEIGHT_ITEM_STARTING_POINT)
					, Quaternion.identity
		);
	}

	void SpawnSkull()
	{
		Instantiate(skullItem, new Vector3(Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT)
					, Constants.instance.HEIGHT_ITEM_STARTING_POINT)
					, Quaternion.identity
		);
	}

	void SpawnWitchHat()
	{
		Instantiate(witchHatItem, new Vector3(Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT)
					, Constants.instance.HEIGHT_ITEM_STARTING_POINT)
					, Quaternion.identity
		);
	}

	void SpawnRedApple()
	{
		Instantiate(redAppleItem, new Vector3(Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT)
					, Constants.instance.HEIGHT_ITEM_STARTING_POINT)
					, Quaternion.identity
		);
	}

	#endregion

}
