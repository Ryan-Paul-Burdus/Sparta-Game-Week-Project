using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float enemyHealth = 100;
    public TextMesh enemyHealthText;
    public GameObject player;
    public GameObject textHolder;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealthText = gameObject.GetComponentInChildren<TextMesh>();
        textHolder = transform.GetChild(1).gameObject;
        enemyHealthText.text = enemyHealth + " / 100";
    }

    private void Update()
    {
        textHolder.transform.rotation = Quaternion.LookRotation(player.transform.position - textHolder.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth -= 15;
            enemyHealthText.text = enemyHealth + " / 100";
            if (enemyHealth <= 0)
            {
                gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }
}
