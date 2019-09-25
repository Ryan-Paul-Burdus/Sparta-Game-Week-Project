using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    private float speed = 50f;
    public GameObject target;
    public GameObject targetBody;
    Vector3 lastKnownPosition = Vector3.zero;
    Quaternion lookAtRotation;
    public GameObject bulletSpawn;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetBody = target.transform.GetChild(0).gameObject;

        bulletSpawn = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, targetBody.transform.position - bulletSpawn.transform.position, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Ground")
            {
                lookAtRotation = Quaternion.Euler(0f, 1f, 1f);// LookRotation(Vector3.forward, Vector3.up);

                if (transform.rotation != lookAtRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                }
            }
            else
            {
                if (target)
                {
                    if (lastKnownPosition != target.transform.position)
                    {
                        lastKnownPosition = target.transform.position;
                        lookAtRotation = Quaternion.LookRotation(lastKnownPosition - transform.position, Vector3.up);
                    }
                    if (transform.rotation != lookAtRotation)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                    }
                }
            }
        }
    }

    bool SetTarget(GameObject curTarget)
    {
        if (target) { return false; }
        target = curTarget;
        return true;
    }
}
