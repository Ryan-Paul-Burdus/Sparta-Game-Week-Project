using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public Text ammoText;
    public GameObject PistolEmitter;
    public GameObject SMGEmitter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            if (PistolEmitter.activeSelf)
            {
                var shootingScript = PistolEmitter.GetComponent<Shooting>();
                shootingScript.AddTotalAmmo(10);
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
            if (SMGEmitter.activeSelf)
            {
                var shootingScript = SMGEmitter.GetComponent<Shooting>();
                shootingScript.AddTotalAmmo(10);
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
            
        }
    }
}
