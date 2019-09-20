using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        if (!Physics.Linecast(transform.position, target.transform.position))
        {
            //shoot
        }
    }
}
