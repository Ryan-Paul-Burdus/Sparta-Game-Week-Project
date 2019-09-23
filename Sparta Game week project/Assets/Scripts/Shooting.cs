using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 500f;
    private bool canShoot = true;
    

    private GameObject playerCamera;

    private float waitTime;
    public string gunType;
    public int maxClipSize;
    public int currentAmmo;

    public Text ammoText;
    private GameObject ammoTextObj;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        ammoTextObj = GameObject.FindGameObjectWithTag("AmmoText");
        ammoText =  ammoTextObj.GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && !gunType.Equals("SMG"))
        {
            if (gunType.Equals("Pistol")) { waitTime = 0.5f; }
            if (currentAmmo > 0)
            {
                StartCoroutine(Shoot());
                this.currentAmmo--;
                ammoText.text = "Ammo = " + currentAmmo + "/" + maxClipSize;
            }

            if (this.currentAmmo <= 0) { StartCoroutine(Reload()); }
        }
        if (Input.GetMouseButton(0) && canShoot && !gunType.Equals("Pistol"))
        {
            if (gunType.Equals("SMG")) { waitTime = 0.1f; }
            if (currentAmmo > 0)
            {
                StartCoroutine(Shoot());
                this.currentAmmo--;
                ammoText.text = "Ammo = " + currentAmmo + "/" + maxClipSize;
            }

            if (this.currentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, playerCamera.transform.rotation) as GameObject;

        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddForce(playerCamera.transform.forward * speed);
        Destroy(instBullet, 5f);
        canShoot = false;
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        currentAmmo = maxClipSize;
        ammoText.text = "Ammo = " + currentAmmo + "/" + maxClipSize;
        yield return new WaitForSeconds(waitTime);
        canShoot = true;

    }
}
