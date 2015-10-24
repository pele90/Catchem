using System.Timers;
using UnityEngine;

public class FallingItemManager : MonoBehaviour
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

	private int randomPosition;

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
		if (pumpkinInstantiateFlag)
		{
			randomPosition = Random.Range(Constants.MIN_ITEM_STARTING_POINT, Constants.MAX_ITEM_STARTING_POINT);
			var startingPosition = new Vector2(randomPosition, Constants.HEIGHT_ITEM_STARTING_POINT);
			Instantiate(pumpkinItem, startingPosition, Quaternion.identity);
			pumpkinInstantiateFlag = false;
		}

		if (redAppleInstantiateFlag)
		{
			randomPosition = Random.Range(Constants.MIN_ITEM_STARTING_POINT, Constants.MAX_ITEM_STARTING_POINT);
			var startingPosition = new Vector2(randomPosition, Constants.HEIGHT_ITEM_STARTING_POINT);
			Instantiate(redAppleItem, startingPosition, Quaternion.identity);
			redAppleInstantiateFlag = false;
		}

		if (witchHatInstantiateFlag)
		{
			randomPosition = Random.Range(Constants.MIN_ITEM_STARTING_POINT, Constants.MAX_ITEM_STARTING_POINT);
			var startingPosition = new Vector2(randomPosition, Constants.HEIGHT_ITEM_STARTING_POINT);
			Instantiate(witchHatItem, startingPosition, Quaternion.identity);
			witchHatInstantiateFlag = false;
		}

		if (skullInstantiateFlag)
		{
			randomPosition = Random.Range(Constants.MIN_ITEM_STARTING_POINT, Constants.MAX_ITEM_STARTING_POINT);
			var startingPosition = new Vector2(randomPosition, Constants.HEIGHT_ITEM_STARTING_POINT);
			Instantiate(skullItem, startingPosition, Quaternion.identity);
			skullInstantiateFlag = false;
		}
	}

	#endregion

	#region Timers

	private void SetupTimers()
	{
		pumpkinTimer.Elapsed += PumpkinEventCallback;
		pumpkinTimer.Interval = TimeUtil.GetMiliseconds(Constants.PUMPKIN_ITEM_FALLING_FREQUENCY);
		pumpkinTimer.Enabled = true;

		redAppleTimer.Elapsed += RedAppleEventCallback;
		redAppleTimer.Interval = TimeUtil.GetMiliseconds(Constants.RED_APPLE_ITEM_FALLING_FREQUENCY);
		redAppleTimer.Enabled = true;

		witchHatTimer.Elapsed += WitchHatEventCallback;
		witchHatTimer.Interval = TimeUtil.GetMiliseconds(Constants.WITCH_HAT_ITEM_FALLING_FREQUENCY);
		witchHatTimer.Enabled = true;

		skullTimer.Elapsed += SkullEventCallback;
		skullTimer.Interval = TimeUtil.GetMiliseconds(Constants.SKULL_ITEM_FALLING_FREQUENCY);
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
