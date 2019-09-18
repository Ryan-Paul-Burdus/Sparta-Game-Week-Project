using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint;
    public bool alive;
    public float lives;

    void Start()
    {
        alive = true;
        lives = 3;
    }
    
    void Update()
    {
        if (alive == false)
        {
            lives--;
            if (lives >= 0)
            {
                transform.position = spawnPoint.position;
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
