using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public Text scoreText;

    public int coins = 0;

    void Start()
    {
        scoreText.text = "Score = " + coins;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coins++;
            Destroy(other.gameObject);
            scoreText.text = "Score = " + coins;
        }
    }
}
