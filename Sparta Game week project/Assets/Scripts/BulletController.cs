using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //hit the player
            Destroy(this.gameObject);
        }
        else { Destroy(this.gameObject); }
    }
}
