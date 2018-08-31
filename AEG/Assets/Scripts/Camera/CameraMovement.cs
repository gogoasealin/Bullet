using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    
    public float speed;
    [SerializeField]private int nextPosition;
    [SerializeField] private float rotationSpeed;
    private float step;
    private float str;
    public Vector3[] location;
    private void Start()
    {
        if (location.Length > 0)
        {
            nextPosition = 0;
        }
        else
        {
            Debug.Log("Camera next location not set");
        }
    }

    void Update()
    {

        step = speed * Time.deltaTime;
        
        //position
        transform.position = Vector3.MoveTowards(transform.position, location[nextPosition], step);
        if (transform.position == location[nextPosition])
        {
            nextPosition++;
            Debug.Log("Going to " + nextPosition + " position");
            if (nextPosition == location.Length)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
                Debug.Log("Moving forward");
            }
        }
    }

    private void LateUpdate()
    {
        //rotation
        if (location[nextPosition] != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(location[nextPosition] - transform.position);
            str = Mathf.Min(0.5f * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str * rotationSpeed);
        }
    }


}
