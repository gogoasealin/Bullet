using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRotationAndroid : MonoBehaviour {

    [SerializeField] private float _sensitivity = 0.4f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private Vector3 touchPos;
    [SerializeField] private bool _isRotating;
    public Camera cam;

    public Text errorText;
    public Text errorText2;
    public Text errorText3;
    public Text errorText4;
    private Touch touch;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;


    public Text button;
    public float count = 0;

    void Start()
    {
        _rotation = Vector3.zero;

        origRot = transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    // Update is called once per frame
    void Update()
    {
        errorText2.text = "" + Input.touchCount;


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

        }else if(touch.phase == TouchPhase.Moved)
        {
            Debug.Log(touchPos);
            Vector3 currentTouchPosition = Input.GetTouch(0).position;
            _mouseOffset = (currentTouchPosition - touchPos);
            errorText3.text = "" + currentTouchPosition;
            errorText4.text = "" + _mouseOffset;

            _rotation.y = +(_mouseOffset.x) * _sensitivity;
            _rotation.z = 0;
            _rotation.x = -(_mouseOffset.y) * _sensitivity;
            transform.eulerAngles += _rotation;
            //stopblocking
            Vector3 targetRotCamera = transform.rotation.eulerAngles;
            if (transform.rotation.eulerAngles.x > 70 && transform.rotation.eulerAngles.x < 150)
            {
                targetRotCamera.x = 70;
            }
            else if (transform.rotation.eulerAngles.x < 300 && transform.rotation.eulerAngles.x > 150)
            {
                targetRotCamera.x = 300;
            }
            //Debug.Log(transform.rotation.eulerAngles);
            transform.rotation = Quaternion.Euler(targetRotCamera);
            // store mouse
            _mouseReference = Input.GetTouch(0).position;
            //Debug.Log(_mouseReference);

        }


    }

    public void Button()
    {
        count++;
        button.text = " Yes " + count;

    }
}
