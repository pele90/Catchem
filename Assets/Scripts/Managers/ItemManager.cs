using System.Timers;
using UnityEngine;


public class ItemManager : MonoBehaviour
{

    #region Fields

    public GameObject[] itemPool;

    // basic unit of time
    public float tickRate = 0.1f;

    // counter for how many ticks won't initialise item
    private int delayCounter = -1;

    // counter for measuring elapsed time in ticks
    private int progressionCounter = 0;

    #endregion

    // Use this for initialization
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        InvokeRepeating("GogoMethod", 0, tickRate);
    }

    #region Methods

    // updating method that is called each tick
    private void GogoMethod()
    {
        if (delayCounter == -1)
        {
            // on first call of the method set delay counter to random value
            delayCounter = Random.Range(1, 10);
        }


        if (delayCounter == 0)
        {
            // getting random number so we can choose random item in item pool
            var randomItem = Random.Range(0, 4);
            // calculating item spawn position
            var randomPosition = Random.Range(Constants.instance.MIN_ITEM_STARTING_POINT, Constants.instance.MAX_ITEM_STARTING_POINT);

            InstantiateRandomItemAtRandomLocaton(randomItem, randomPosition);

            // calculate random number of ticks when not to instantiate item
            if (progressionCounter < 50)
            {
                delayCounter = Random.Range(10, 20);
            }
            else if(progressionCounter > 50 && progressionCounter < 150)
            {
                delayCounter = Random.Range(1, 20);
            }
            else if(progressionCounter > 150 && progressionCounter < 300)
            {
                delayCounter = Random.Range(1, 10);
            }
            else
            {
                delayCounter = Random.Range(1, 5);
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

    #endregion




}
