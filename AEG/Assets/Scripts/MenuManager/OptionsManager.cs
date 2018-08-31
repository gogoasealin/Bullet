using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

    public float sensitivity ;
    [SerializeField] private Text sensitivityText;

    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] MenuManager menuManager;


    public void Start()
    {
        sensitivity = 2f;
        sensitivityText.text = "" + Convert.ToInt32(sensitivity); // Set sensitivity first
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        menuManager.sensitivity = this.sensitivity;
    }


    public void SetSensitivity(float sensitivity)
    {
        this.sensitivity = sensitivity;
        sensitivityText.text = "" + sensitivity.ToString("F2");//Convert.ToInt32(sensitivity);
        menuManager.sensitivity = this.sensitivity;
    }

    public void ShowOption()
    {
        optionsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ShowMenu()
    {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

}

 