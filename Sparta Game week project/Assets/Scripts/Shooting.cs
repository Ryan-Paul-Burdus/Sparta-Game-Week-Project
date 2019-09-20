using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 350f;
    private bool canShoot = true;

    private GameObject playerCamera;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddForce(playerCamera.transform.forward * speed);
        Destroy(instBullet, 5f);
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
