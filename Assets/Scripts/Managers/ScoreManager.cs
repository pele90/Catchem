using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Debug.Log(GameManager.Score.ToString());
        GetComponent<Text>().text = "Your score is: " + GameManager.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
