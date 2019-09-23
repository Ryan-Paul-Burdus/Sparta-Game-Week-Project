using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private GameObject playerHolder;
    public float speed = 2f;

    private GameObject position1;
    private GameObject position2;
    bool lastOnPos1 = true;

    private Transform parent;

    private void Start()
    {
        playerHolder = GameObject.FindGameObjectWithTag("PlayerHolder");
        parent = transform.parent;
        position1 = parent.GetChild(1).gameObject;
        position2 = parent.GetChild(2).gameObject;
        transform.position = position1.transform.position;
    }

    private void Update()
    {

        if (transform.position == position1.transform.position)
        {
            lastOnPos1 = true;
        }
        if (transform.position == position2.transform.position)
        {
            lastOnPos1 = false;
        }

        if (lastOnPos1) { transform.position = Vector3.MoveTowards(transform.position, position2.transform.position, speed * Time.deltaTime); }
        else { transform.position = Vector3.MoveTowards(transform.position, position1.transform.position, speed * Time.deltaTime); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = playerHolder.transform;
        }
    }
}
