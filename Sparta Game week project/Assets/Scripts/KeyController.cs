using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject door;
    public GameObject doorText;

    private void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        doorText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            door.transform.Translate(0f, 3f, 0f);
            doorText.SetActive(true);
        }
    }
}
