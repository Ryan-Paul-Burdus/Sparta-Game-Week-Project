using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public Text ammoText;

    public int totalAmmo = 20;
    public int currentAmmo;
    public int maxClipAmmo = 8;

    private void Start()
    {
        currentAmmo = maxClipAmmo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            other.gameObject.SetActive(false);
            totalAmmo += 10;
            Destroy(other.gameObject);
            ammoText.text = "Ammo = " + currentAmmo + "/" + totalAmmo;
        }
    }
}
