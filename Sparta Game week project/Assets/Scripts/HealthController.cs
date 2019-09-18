using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health = 100;
    public Text healthText;

    private void Start()
    {
        healthText.text = "Health = " + health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            other.gameObject.SetActive(false);
            health += 20;
            Destroy(other.gameObject);
            healthText.text = "Health = " + health;
        }
    }
}
