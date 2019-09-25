using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public GameObject player;
    public GameObject[] platforms;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        platforms = GameObject.FindGameObjectsWithTag("Platform");


        foreach (GameObject platform in platforms)
        {
            if (platform.GetComponent<MeshRenderer>().material.name.Equals("Black"))
            {
                platform.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                platform.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
            foreach (GameObject platform in platforms)
            {

                if (this.GetComponent<MeshRenderer>().material.name.Contains(platform.GetComponent<MeshRenderer>().material.name))
                {
                    platform.GetComponent<BoxCollider>().enabled = true;
                }
                else
                {
                    platform.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }
}
