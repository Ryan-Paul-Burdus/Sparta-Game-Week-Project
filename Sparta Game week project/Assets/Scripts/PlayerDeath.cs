using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint;
    public bool alive;
    public float lives;
    public Text healthText;
    HealthController healthController;

    void Start()
    {
        healthController = gameObject.GetComponent<HealthController>();

        alive = true;
        lives = 3;
        healthText.text = "Health = 100";
    }
    
    void Update()
    {
        if (alive == false)
        {
            lives--;
            if (lives >= 0)
            {
                transform.position = spawnPoint.position;
                healthController.canBeHit = true;
                alive = true;
            }
            if (lives < 0)
            {
                //load the game over screen
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathObject"))
        {
            alive = false;
            
        }
        else
        {
            alive = true;
        }
    }
}
