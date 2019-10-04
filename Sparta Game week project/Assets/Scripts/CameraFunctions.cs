using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunctions : MonoBehaviour
{
    //values for the angles allowed for the camera rotation 
    private float minXAngle = -60f;
    private float maxXAngle = 60f;

    //values for the cameras sensitivity
    private float xSensitivity = 1.5f;
    private float ySensitivity = 1.5f;

    //gets the camera object 
    public Camera playerCam;

    //sets the rotation of the camera to 0 
    float xRot = 0f;
    float yRot = 0f;

    //this locks the cursor to the middle of the screen at all times whilst the game is running
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (MenuSystem.isPaused)
        {
            yRot += Input.GetAxis("Mouse X") * 0f;
            xRot += Input.GetAxis("Mouse Y") * 0f;
        }
        else
        {
            yRot += Input.GetAxis("Mouse X") * ySensitivity;
            xRot += Input.GetAxis("Mouse Y") * xSensitivity;
        }

        //this keeps the player from looking further than a certain angle in the x direction
        xRot = Mathf.Clamp(xRot, minXAngle, maxXAngle);

        //this controls the movement  of both the player and the camera so they are syncronized
        transform.localEulerAngles = new Vector3(0, yRot, 0);
        playerCam.transform.localEulerAngles = new Vector3(-xRot, yRot, 0);
    }
}
