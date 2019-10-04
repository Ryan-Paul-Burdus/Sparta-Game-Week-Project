using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    CoinController coinController;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        coinController = player.GetComponent<CoinController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Score", coinController.score);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (SceneManager.GetActiveScene().name == "Level1SP")
            {
                SceneManager.LoadScene("Level2SP");
            }
            if (SceneManager.GetActiveScene().name == "Level2SP")
            {
                SceneManager.LoadScene("EndOfGameScreen");
            }
        }
    }
}
