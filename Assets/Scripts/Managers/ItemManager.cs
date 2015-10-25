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
	//public GameObject lifeHeartItem;

	// timers
	private Timer pumpkinTimer;
	private Timer redAppleTimer;
	private Timer skullTimer;
	private Timer witchHatTimer;
	private Timer lifeHeartTimer;

	private float randomPosition;

	private bool pumpkinInstantiateFlag;
	private bool redAppleInstantiateFlag;
	private bool witchHatInstantiateFlag;
	private bool skullInstantiateFlag;


	#endregion

	#region Unity Methods

	// Use this for initialization
	void Start()
	{
		pumpkinInstantiateFlag = false;
		redAppleInstantiateFlag = false;
		witchHatInstantiateFlag = false;
		skullInstantiateFlag = false;

		pumpkinTimer = new Timer();
		redAppleTimer = new Timer();
		skullTimer = new Timer();
		witchHatTimer = new Timer();
		//lifeHeartTimer = new Timer();

		SetupTimers();
	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.NumberOfItemsToFall != 0)
		{
			if (GameManager.instance.Paused)
			{
				PauseTimers();
			}
			else
			{
				UnPauseTimers();
				
				if (pumpkinInstantiateFlag)
				{
					// get random number from left wall to right wall of the scene to get starting x position to instantiate item
					randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);
					// create Vector2 starting position to instantiate an item
					var startingPosition = new Vector2(randomPosition, Constants.instance.HEIGHT_ITEM_STARTING_POINT);
					// instantiate an item
					Instantiate(pumpkinItem, startingPosition, Quaternion.identity);
					// decrease number of falled item counter
					GameManager.instance.NumberOfItemsToFall--;
					// set flag to false so that item won't be created each updated
					pumpkinInstantiateFlag = false;
				}

				if (redAppleInstantiateFlag)
				{
					randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);
					var startingPosition = new Vector2(randomPosition, Constants.instance.HEIGHT_ITEM_STARTING_POINT);
					Instantiate(redAppleItem, startingPosition, Quaternion.identity);
					GameManager.instance.NumberOfItemsToFall--;
					redAppleInstantiateFlag = false;
				}

				if (witchHatInstantiateFlag)
				{
					randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);
					var startingPosition = new Vector2(randomPosition, Constants.instance.HEIGHT_ITEM_STARTING_POINT);
					Instantiate(witchHatItem, startingPosition, Quaternion.identity);
					GameManager.instance.NumberOfItemsToFall--;
					witchHatInstantiateFlag = false;
				}

				if (skullInstantiateFlag)
				{
					randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);
					var startingPosition = new Vector2(randomPosition, Constants.instance.HEIGHT_ITEM_STARTING_POINT);
					Instantiate(skullItem, startingPosition, Quaternion.identity);
					GameManager.instance.NumberOfItemsToFall--;
					skullInstantiateFlag = false;
				}
			}
		}
	}

	#endregion

	#region Timers

	private void SetupTimers()
	{
		pumpkinTimer.Elapsed += PumpkinEventCallback;
		pumpkinTimer.Interval = TimeUtil.GetMiliseconds(Constants.instance.PUMPKIN_ITEM_FALLING_FREQUENCY);
		pumpkinTimer.Enabled = true;

		redAppleTimer.Elapsed += RedAppleEventCallback;
		redAppleTimer.Interval = TimeUtil.GetMiliseconds(Constants.instance.RED_APPLE_ITEM_FALLING_FREQUENCY);
		redAppleTimer.Enabled = true;

		witchHatTimer.Elapsed += WitchHatEventCallback;
		witchHatTimer.Interval = TimeUtil.GetMiliseconds(Constants.instance.WITCH_HAT_ITEM_FALLING_FREQUENCY);
		witchHatTimer.Enabled = true;

		skullTimer.Elapsed += SkullEventCallback;
		skullTimer.Interval = TimeUtil.GetMiliseconds(Constants.instance.SKULL_ITEM_FALLING_FREQUENCY);
		skullTimer.Enabled = true;
	}

	private void PauseTimers()
	{
		pumpkinTimer.Enabled = false;
		redAppleTimer.Enabled = false;
		witchHatTimer.Enabled = false;
		skullTimer.Enabled = false;
	}

	private void UnPauseTimers()
	{
		pumpkinTimer.Enabled = true;
		redAppleTimer.Enabled = true;
		witchHatTimer.Enabled = true;
		skullTimer.Enabled = true;
	}

	#endregion

	#region CallBack

	private void PumpkinEventCallback(object source, ElapsedEventArgs e)
	{
		pumpkinInstantiateFlag = true;
	}

	private void RedAppleEventCallback(object source, ElapsedEventArgs e)
	{
		redAppleInstantiateFlag = true;
	}

	private void WitchHatEventCallback(object source, ElapsedEventArgs e)
	{
		witchHatInstantiateFlag = true;
	}

	private void SkullEventCallback(object source, ElapsedEventArgs e)
	{
		skullInstantiateFlag = true;
	}

	#endregion
}
