using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    //this gets the player object
    public GameObject player;

    //this gets the difference in distance between the camera and the player object
    private Vector3 offset;
    private Vector3 crouchDistance;

    void Start()
    {
        //gets the offset location for the camera
        offset = transform.position - player.transform.position;
    }

    //this makes the camera object follow the movements of the player object
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            PlayerController.isCrouching = true;
            crouchDistance = new Vector3(0, 0.5f, 0);
        }
        if (Input.GetButtonUp("Crouch"))
        {
            PlayerController.isCrouching = false;
            crouchDistance = new Vector3(0, 0, 0);
        }

        transform.position = player.transform.position + offset - crouchDistance;
    }
}
