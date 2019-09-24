using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Text ammoText;
    private GameObject ammoTextObj;

    void Start()
    {
        ammoTextObj = GameObject.FindGameObjectWithTag("AmmoText");
        ammoText = ammoTextObj.GetComponent<Text>();
        SelectWeapon();
        var currentGun = gameObject.GetComponentInChildren<Shooting>();
        ammoText.text = "Ammo = " + currentGun.currentAmmo + "/" + currentGun.totalAmmo;
    }

    
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1) { selectedWeapon = 0; }
            else { selectedWeapon++; }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0) { selectedWeapon = transform.childCount - 1; }
            else { selectedWeapon--; }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { selectedWeapon = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { selectedWeapon = 1; }


        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                var currentGun = gameObject.GetComponentInChildren<Shooting>();
                ammoText.text = "Ammo = " + currentGun.currentAmmo + "/" + currentGun.totalAmmo;
            }
            else { weapon.gameObject.SetActive(false); }
            i++;
        }
    }
}
