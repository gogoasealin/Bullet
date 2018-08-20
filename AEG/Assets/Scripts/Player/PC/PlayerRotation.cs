using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRotation : MonoBehaviour {

    [SerializeField] private float _sensitivity = 0.4f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    [SerializeField] private bool _isRotating;

    public Text button;
    public float count = 0;
    void Start()
    {
        _rotation = Vector3.zero;
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
                targetRotCam.x = 70;
            }
            else if(transform.rotation.eulerAngles.x < 300 && transform.rotation.eulerAngles.x > 150)
            {
                targetRotCam.x = 300;
            }
            //Debug.Log(transform.rotation.eulerAngles);
            transform.rotation = Quaternion.Euler(targetRotCam);
            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    public void Button()
    {
        count++;
        button.text = " Yes " + count ;


    }


}
