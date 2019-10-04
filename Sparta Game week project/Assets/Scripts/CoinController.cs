using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    public Text scoreText;

    public int score;

    AudioSource audioSource;

    public AudioClip coinClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name.Equals("Level1SP"))
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("Score");
        }
        scoreText.text = "Score = " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.clip = coinClip;
            audioSource.Play();
            other.gameObject.SetActive(false);
            score++;
            Destroy(other.gameObject);
            scoreText.text = "Score = " + score;
        }
    }
}
