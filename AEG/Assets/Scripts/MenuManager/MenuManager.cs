using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour {


    public float sensitivity;

    private static bool MenuManagerExists;

    void Start()
    {
        if (!MenuManagerExists) //if GameManagerexcistst is not true --> this action will happen.
        {
            DontDestroyOnLoad(transform.gameObject);
            MenuManagerExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
