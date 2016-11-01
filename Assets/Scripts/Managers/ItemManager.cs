using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    [System.Serializable]
    public struct SpecialItem
    {
        public string name;
        public GameObject specialItem;
    }

    #region Fields

    public GameObject[] itemPool;
    public SpecialItem[] specialItemPool;
    private Dictionary<string, GameObject> dictSpecialItem;


    // basic unit of time
    public float tickRate = 0.1f;

    // counter for how many ticks won't initialise item
    private int delayCounter = -1;

    // counter for measuring elapsed time in ticks
    private int progressionCounter = 0;

    #endregion

    #region Methods

    // Use this for initialization
    void Start()
    {
        dictSpecialItem = new Dictionary<string, GameObject>();
        foreach (var item in specialItemPool)
        {
            dictSpecialItem.Add(item.name, item.specialItem);
        }
        Random.InitState((int)System.DateTime.Now.Ticks);
        InvokeRepeating("GogoMethod", 0, tickRate);
    }

    // updating method that is called each tick
    private void GogoMethod()
    {
        if (delayCounter == -1)
        {
            // on first call of the method set delay counter to random value
            delayCounter = Random.Range(Constants.instance.MIN_WAIT_TIME, Constants.instance.HARD_MIN_WAIT_TIME);
        }

        if(progressionCounter != 0 && progressionCounter % 300 == 0)
        {
            var randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);
            InstantiateGameObject(dictSpecialItem["lifeHeart"], randomPosition);
        }

        if (progressionCounter != 0 && progressionCounter % 400 == 0)
        {
            var randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);
            InstantiateGameObject(dictSpecialItem["whiteFeather"], randomPosition);
        }

        if (delayCounter == 0)
        {
            // getting random number so we can choose random item in item pool
			var randomItem = Random.Range(Constants.instance.ZERO, Constants.instance.TOTAL_NUMBER_OF_ITEMS);
            // calculating item spawn position
            var randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);

            InstantiateRandomItemAtRandomLocaton(randomItem, randomPosition);

            // calculate random number of ticks when not to instantiate item
            if (progressionCounter < Constants.instance.FIRST_THRESHOLD)
            {
                delayCounter = Random.Range(Constants.instance.EASY_MIN_WAIT_TIME, Constants.instance.EASY_MAX_WAIT_TIME);
            }
			else if (progressionCounter > Constants.instance.FIRST_THRESHOLD && progressionCounter < Constants.instance.SECOND_THRESHOLD)
            {
                delayCounter = Random.Range(Constants.instance.MIN_WAIT_TIME, Constants.instance.EASY_MAX_WAIT_TIME);
            }
            else if(progressionCounter > Constants.instance.SECOND_THRESHOLD && progressionCounter < Constants.instance.THIRD_THRESHOLD)
            {
                delayCounter = Random.Range(Constants.instance.MIN_WAIT_TIME, Constants.instance.HARD_MAX_WAIT_TIME);
            }
            else
            {
                delayCounter = Random.Range(Constants.instance.MIN_WAIT_TIME, 5);
            }
        }
        else
        {
            delayCounter--;
        }

        progressionCounter++;
    }

    private void InstantiateRandomItemAtRandomLocaton(int randomNumber, float randomSpawnPosition)
    {
        // choosing item from item pool
        var randomItem = itemPool[randomNumber];

            Instantiate(randomItem, new Vector2(randomSpawnPosition
                                            , Constants.instance.HEIGHT_ITEM_STARTING_POINT)
                                            , Quaternion.identity);
    }

    private void InstantiateGameObject(GameObject p_gameobject, float randomSpawnPosition)
    {
        Instantiate(p_gameobject, new Vector2(randomSpawnPosition
                                            , Constants.instance.HEIGHT_ITEM_STARTING_POINT)
                                            , Quaternion.identity);
    }

    #endregion




}
