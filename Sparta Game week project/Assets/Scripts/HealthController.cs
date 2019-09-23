using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health = 100;
    public bool canBeHit;
    public Text healthText;
    PlayerDeath playerDeath;

    private void Start()
    {
        canBeHit = true;
        healthText.text = "Health = " + health;
        playerDeath = gameObject.GetComponent<PlayerDeath>();
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

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            if (canBeHit)
            {
                health -= 10;
                healthText.text = "Health = " + health;
                if (health <= 0)
                {
                    canBeHit = false;
                    health = 100;
                    playerDeath.alive = false;
                    healthText.text = "Health = " + health;
                }
            }
            
        }
    }
}
