using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject player;
	
	void Awake () {
#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        Debug.Log("Unity Editor");
        //Destroy(player.GetComponent<PlayerRotationAndroid>());
#elif UNITY_IOS
        Debug.Log("Iphone");
        Destroy(player.GetComponent<PlayerRotation>());
#elif UNITY_ANDROID
        Debug.Log("Android");
        Destroy(player.GetComponent<PlayerRotation>());
#endif
    }



}
