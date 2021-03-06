﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRotation : MonoBehaviour {

    //Player Movement
    [SerializeField] private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    [SerializeField] private bool _isRotating;

    // PowerUps
    private bool slowTime;

    // Managers
    private MenuManager menuManager;

    void Start()
    {
        _rotation = Vector3.zero;
        if (GameObject.Find("MenuManager") != null)
        {
            menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            _sensitivity = menuManager.sensitivity / 10;
        }
        else
        {
            Debug.Log("No MenuManager found");
        }
    }

    // Update is called once per frame
    void LateUpdate() {
        if (Input.GetMouseButtonDown(0))
        {
            // rotating flag
           _isRotating = true;
            // store mouse
            _mouseReference = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
            return;
        }
        //move forward
  
        if (_isRotating)
        {
            //offset
            _mouseOffset = (Input.mousePosition - _mouseReference );

            // apply rotation
            //_rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
            _rotation.y = +(_mouseOffset.x) * _sensitivity;
            _rotation.z = 0;
            _rotation.x = -(_mouseOffset.y) * _sensitivity;


            //transform.Rotate(_rotation.x, _rotation.y, 0, Space.Self);
            transform.eulerAngles += _rotation ;
            //stopblocking
            Vector3 targetRotCam = transform.rotation.eulerAngles;
            if(transform.rotation.eulerAngles.x > 70 && transform.rotation.eulerAngles.x < 150)
            {
                targetRotCam.x = 70;//70
            }
            else if(transform.rotation.eulerAngles.x < 300 && transform.rotation.eulerAngles.x > 150)
            {
                targetRotCam.x = 300;//300
            }
            if (transform.rotation.eulerAngles.y > 70 && transform.rotation.eulerAngles.y < 150)
            {
                targetRotCam.y = 70;
            }
            else if (transform.rotation.eulerAngles.y < 290 && transform.rotation.eulerAngles.y > 150)
            {
                targetRotCam.y = 290;
            }
            //Debug.Log(transform.rotation.eulerAngles);
            transform.rotation = Quaternion.Euler(targetRotCam);
            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    public void PowerUp()
    {
        slowTime = !slowTime;
        if (slowTime)
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void RestartCurrentScene()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
