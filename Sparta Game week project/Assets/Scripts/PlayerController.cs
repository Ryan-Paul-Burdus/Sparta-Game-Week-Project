using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 moveDirection;

    public float speed;
    private float crouchSpeed = 80.0f;
    private float walkSpeed = 150.0f;
    private float runSpeed = 275.0f;

    public bool onGround;
    public static bool isCrouching = false;
    private bool isRunning = false;

    public GameObject redBorder;
    public GameObject orangeBorder;
    public GameObject greenBorder;
    public GameObject blueBorder;
    public GameObject baseBorder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;

        redBorder.SetActive(false);
        greenBorder.SetActive(false);
        blueBorder.SetActive(false);
        orangeBorder.SetActive(false);
        baseBorder.SetActive(true);
    }

    void Update()
    {
        //gets the players movement input from both "wasd" and "^v<>"
        float horAxis = Input.GetAxisRaw("Horizontal");
        float verAxis = Input.GetAxisRaw("Vertical");

        //this makes the direction and makes it so you can move in a 45 degree angle in any direction aswell 
        moveDirection = (horAxis * transform.right + verAxis * transform.forward).normalized;
        
        if (onGround)
        {
            //this allows the player to jump, but only if the player is on a surface
            if (Input.GetButtonDown("Jump") && !isCrouching)
            {
                rb.velocity = new Vector3(0f, 4f, 0f);
                onGround = false;
            }
        }
    }

    private void FixedUpdate()
    {
        //creates a vector for the movement and moves the player in that direction by the given speed
        Vector3 yVel = new Vector3(0, rb.velocity.y, 0);
        speed = walkSpeed;

        //speeds up the player if theyre running, and puts them to walking speed if not
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            isRunning = true;
        }
        if (!Input.GetKey(KeyCode.W)) { isRunning = false; }

        //sets the speed of the player
        if (isRunning && !isCrouching) { speed = runSpeed; }
        else if (isCrouching)
        {
            speed = crouchSpeed;
            isRunning = false;
        }
        else { speed = walkSpeed; }

        //sets both the speed and upward velocity of player 
        rb.velocity = moveDirection * speed * Time.deltaTime;
        rb.velocity += yVel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //makes it so that anything with the tag "ground" will allow the player to jump
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }
        colorSetter(collision);
    }

    public void colorSetter(Collision collision)
    {
        if (collision.gameObject.name == "Blue color-changing platform")
        {
            redBorder.SetActive(false);
            greenBorder.SetActive(false);
            blueBorder.SetActive(true);
            orangeBorder.SetActive(false);
            baseBorder.SetActive(false);
        }
        if (collision.gameObject.name == "Red color-changing platform")
        {
            redBorder.SetActive(true);
            greenBorder.SetActive(false);
            blueBorder.SetActive(false);
            orangeBorder.SetActive(false);
            baseBorder.SetActive(false);
        }
        if (collision.gameObject.name == "Orange color-changing platform")
        {
            redBorder.SetActive(false);
            greenBorder.SetActive(false);
            blueBorder.SetActive(false);
            orangeBorder.SetActive(true);
            baseBorder.SetActive(false);
        }
        if (collision.gameObject.name == "Green color-changing platform")
        {
            redBorder.SetActive(false);
            greenBorder.SetActive(true);
            blueBorder.SetActive(false);
            orangeBorder.SetActive(false);
            baseBorder.SetActive(false);
        }
    }
}
