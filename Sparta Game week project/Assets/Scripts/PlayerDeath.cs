using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint;
    public bool alive;
    public float lives;
    public Text healthText;
    HealthController healthController;

    string fileName = "Scores.txt";
    CoinController coinController;
    

    void Start()
    {
        healthController = gameObject.GetComponent<HealthController>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        coinController = player.GetComponent<CoinController>();

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
                if (!File.Exists(fileName)) { File.WriteAllText(fileName, $"{coinController.score}"); }
                File.AppendAllText(fileName, $"\n\n{coinController.score}");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("GameOverScreen");
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
