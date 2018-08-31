using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDragging : MonoBehaviour {

    //Player Movement
    [SerializeField] private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _localPosition;
    [SerializeField] private bool _isRotating;
    
    // PowerUps
    private bool slowTime;

    // Managers
    private MenuManager menuManager;

    //Scripts
    [SerializeField] Camera cam;



    void Start()
    {
        _localPosition = Vector3.zero;

        if (GameObject.Find("MenuManager") != null)
        {
            menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            _sensitivity = menuManager.sensitivity / 500;
        }
        else
        {
            _sensitivity = 2f/ 500;
            Debug.Log("No MenuManager found");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("draw" + transform.position);

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
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            //_rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
            _localPosition.y = +(_mouseOffset.y) * _sensitivity;
            _localPosition.z = 0;
            _localPosition.x = (_mouseOffset.x) * _sensitivity;



            //stopblocking
            Vector3 playerPosition = cam.WorldToViewportPoint(transform.position);

            if (playerPosition.x < 0.1f && _localPosition.x < 0)
            {
                _localPosition.x = 0f;
            }
            else if (playerPosition.x > 0.9f && _localPosition.x > 0)
            {
                _localPosition.x = 0f;
            }

            if (playerPosition.y < 0.1f && _localPosition.y < 0)
            {
                _localPosition.y = 0f;
            }
            else if (playerPosition.y > 0.9f && _localPosition.y > 0)
            {
                _localPosition.y = 0f;
            }
            
            
            transform.localPosition += _localPosition;
            
            //rb.MovePosition(rb.position + _localPosition);

            
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
