using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCameraMovement : MonoBehaviour {

    Camera camActual;
    [SerializeField] Camera cam;

    private void Start()
    {
        camActual = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 camPosition = cam.WorldToViewportPoint(cam.transform.position);
        Debug.Log(camActual.WorldToViewportPoint(camPosition));
        //if (camPosition.x > 0.7f)
        //{

        //    cam.transform.position -= Vector3.left;
        //}
        //else if (camPosition.x < 0.3f)
        //{
        //    transform.position -= transform.right;
        //}

        //if (camPosition.y > 0.7f )
        //{
        //    transform.position += transform.up;
        //}
        //else if (camPosition.y < 0.3f )
        //{
        //    transform.position -= transform.up;
        //}
    }
}
