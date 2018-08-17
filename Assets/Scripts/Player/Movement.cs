using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]private Rigidbody rb;
    public float speed = 10f;



    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }




}
