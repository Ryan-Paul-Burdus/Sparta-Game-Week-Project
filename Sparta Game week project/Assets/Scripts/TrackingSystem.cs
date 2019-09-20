using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 30f;
    public GameObject target = null;
    Vector3 lastKnownPosition = Vector3.zero;
    Quaternion lookAtRotation;


    void Update()
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

    bool SetTarget(GameObject curTarget)
    {
        if (target) { return false; }
        target = curTarget;
        return true;
    }
}
