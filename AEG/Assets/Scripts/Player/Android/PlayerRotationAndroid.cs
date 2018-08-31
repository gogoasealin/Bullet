using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRotationAndroid : MonoBehaviour {

    // PlayerMovement
    [SerializeField] private float _sensitivity;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private Vector3 touchPos;
    [SerializeField] private bool _isRotating;
    public Camera cam;
    private Touch touch;

    // Debuging
    [SerializeField]private Text errorText;


    //PowerUps
    private bool slowTime;

    // Managers
    [SerializeField] private MenuManager menuManager;


    void Start()
    {
        _rotation = Vector3.zero;
        if (GameObject.Find("MenuManager"))
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
    void Update()
    {
        //errorText2.text = "" + Input.touchCount;
        //Vector3 touchPos = cam.ScreenToWorldPoint(touch.position);
        errorText.text = "fps " + (1.0f / Time.deltaTime).ToString("F2");

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        else
        {
            return;
        }

        if (touch.phase == TouchPhase.Began)
        {
            touchPos = touch.position;
            //errorText.text = "" + touchPos;

        } else if (touch.phase == TouchPhase.Moved)
        {
            //Debug.Log(touchPos);
            Vector3 currentTouchPosition = Input.GetTouch(0).position;
            _mouseOffset = (currentTouchPosition - touchPos);

            _rotation.y = +(_mouseOffset.x) * _sensitivity;
            _rotation.z = 0;
            _rotation.x = -(_mouseOffset.y) * _sensitivity;
            transform.eulerAngles += _rotation;
            //stopblocking
            Vector3 targetRotCamera = transform.rotation.eulerAngles;
            if (transform.rotation.eulerAngles.x > 30 && transform.rotation.eulerAngles.x < 150)
            {
                targetRotCamera.x = 30;
            }
            else if (transform.rotation.eulerAngles.x < 330 && transform.rotation.eulerAngles.x > 150)
            {
                targetRotCamera.x = 330;
            }

            if (transform.rotation.eulerAngles.y > 40 && transform.rotation.eulerAngles.y < 150)
            {
                targetRotCamera.y = 40;
            }
            else if (transform.rotation.eulerAngles.y < 320 && transform.rotation.eulerAngles.y > 150)
            {
                targetRotCamera.y = 320;
            }
            //Debug.Log(transform.rotation.eulerAngles);
            transform.rotation = Quaternion.Euler(targetRotCamera);
            // store mouse
            touchPos = Input.GetTouch(0).position;
            //Debug.Log(_mouseReference);

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
