using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public Text ammoText;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            //var shootingController = GetComponent<Shooting>();
            other.gameObject.SetActive(false);
            //shootingController totalAmmo += 10;
            Destroy(other.gameObject);
            //ammoText.text = "Ammo = " + shootingController.currentAmmo + "/" + shootingController.maxClipSize;
        }
    }
}
