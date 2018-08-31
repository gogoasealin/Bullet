using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingForPlayer : MonoBehaviour {

    [SerializeField] private GameObject player;
    Camera cam;
    public float cameraSensibility = 5f;
    public bool[] canMove ;

    // Members
    private float range = 1f;
    private Vector3[] CheckBlockPositions = new Vector3[4];

    private void Start()
    {
        cam = GetComponent<Camera>();
        canMove = new bool[4];
        CanMove();

        CheckBlockPositions[0] = Vector3.right;
        CheckBlockPositions[1] = Vector3.left;
        CheckBlockPositions[2] = Vector3.up;
        CheckBlockPositions[3] = Vector3.down;

    }



    void Update()
    {
        CheckBlock();
        Vector3 playerPosition = cam.WorldToViewportPoint(player.transform.position);
        if (playerPosition.x > 0.7f && canMove[0])
        {
            transform.position += transform.right * cameraSensibility;        
        }
        else if (playerPosition.x < 0.3f && canMove[1])
        {
            transform.position -= transform.right * cameraSensibility;
        }

        if (playerPosition.y > 0.7f && canMove[2])
        {
            transform.position += transform.up * cameraSensibility;
        }
        else if (playerPosition.y < 0.3f && canMove[3])
        {
            transform.position -= transform.up * cameraSensibility;
        }

        
    }



    public void CheckBlock()
    {
        RaycastHit hit;
        for (int i = 0; i < CheckBlockPositions.Length; i++)
        {
            //Vector3 rayPosition = player.transform.position + player.transform.localPosition;
            Debug.DrawRay(player.transform.position, CheckBlockPositions[i] * range, Color.cyan);

            if (Physics.Raycast(player.transform.position, CheckBlockPositions[i], out hit, range, 1<<9))
            {
                canMove[i] = false;
            }
            else
            {
                canMove[i] = true;
            }
        }
    }



    public void CanMove()
    {
        for (int i = 0; i < canMove.Length; i++)
        {
            canMove[i] = true;
        }
    }

}
