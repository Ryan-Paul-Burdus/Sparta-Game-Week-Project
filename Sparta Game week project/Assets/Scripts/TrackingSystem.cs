using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    private float speed = 50f;
    public GameObject target = null;
    public GameObject targetBody;
    Vector3 lastKnownPosition = Vector3.zero;
    Quaternion lookAtRotation;
    public GameObject bulletSpawn;

    private void Start()
    {
        bulletSpawn = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, targetBody.transform.position - bulletSpawn.transform.position, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Ground")
            {
                lookAtRotation = Quaternion.LookRotation(Vector3.zero, Vector3.up);
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
