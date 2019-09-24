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
    public int totalAmmo;

    public Text ammoText;
    private GameObject ammoTextObj;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        ammoTextObj = GameObject.FindGameObjectWithTag("AmmoText");
        ammoText =  ammoTextObj.GetComponent<Text>();
    }

    public void AddTotalAmmo(int amountToAdd)
    {
        this.totalAmmo += amountToAdd;
        ammoText.text = "Ammo = " + this.currentAmmo + "/" + this.totalAmmo;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && !gunType.Equals("SMG"))
        {
            if (gunType.Equals("Pistol")) { waitTime = 0.5f; }
            if (currentAmmo > 0)
            {
                StartCoroutine(Shoot());
            }
            if (this.currentAmmo <= 0) { StartCoroutine(Reload()); }
        }
        if (Input.GetMouseButton(0) && canShoot && !gunType.Equals("Pistol"))
        {
            if (gunType.Equals("SMG")) { waitTime = 0.1f; }
            if (currentAmmo > 0)
            {
                StartCoroutine(Shoot());
            }
        }

        if (Input.GetKeyDown(KeyCode.R) || this.currentAmmo <= 0)
        {
            Debug.Log("R");
            StartCoroutine(Reload());
        }
    }

    IEnumerator Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, playerCamera.transform.rotation) as GameObject;
        this.currentAmmo--;
        ammoText.text = "Ammo = " + this.currentAmmo + "/" + this.totalAmmo;
        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddForce(playerCamera.transform.forward * speed);
        Destroy(instBullet, 5f);
        canShoot = false;
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    IEnumerator Reload()
    {
        if (this.currentAmmo != this.maxClipSize)
        {
            canShoot = false;
            yield return new WaitForSeconds(1f);

            if (this.maxClipSize >= this.totalAmmo && (this.maxClipSize - this.currentAmmo) >= this.totalAmmo)
            {
                this.currentAmmo += this.totalAmmo;
                this.totalAmmo = 0;
            }
            else
            {
                if (this.currentAmmo <= 0)
                {
                    this.totalAmmo -= this.maxClipSize;
                }
                else
                {
                    this.totalAmmo -= (this.maxClipSize - this.currentAmmo);
                }
                this.currentAmmo = this.maxClipSize;
            }
            
            ammoText.text = "Ammo = " + this.currentAmmo + "/" + this.totalAmmo;
            yield return new WaitForSeconds(waitTime);
            canShoot = true;
        }
    }
}
