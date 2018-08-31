using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    public float speed = 50f;



    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
