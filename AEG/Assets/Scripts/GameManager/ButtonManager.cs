using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    [SerializeField] private GameObject PCButton;
    [SerializeField] private GameObject AndroidButton;

    void Awake()
    {
#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        //Debug.Log("Unity Editor");
        Destroy(AndroidButton);
#elif UNITY_IOS
        //Debug.Log("Iphone");
        Destroy(PCButton);
#elif UNITY_ANDROID
        //Debug.Log("Android");
        Destroy(PCButton);
#endif
    }
}
