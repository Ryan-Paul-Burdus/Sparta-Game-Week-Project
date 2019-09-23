using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //hit the enemy
            Destroy(this.gameObject);
        }
        else { Destroy(this.gameObject); }
    }
}
