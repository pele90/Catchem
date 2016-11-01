using UnityEngine;
using System.Collections;

public class DestroyOnNonMobile : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
#if !UNITY_ANDROID
        Destroy(gameObject);
#endif
    }

}
