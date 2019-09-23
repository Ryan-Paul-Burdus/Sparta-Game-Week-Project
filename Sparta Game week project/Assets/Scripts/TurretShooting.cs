using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject target;
    public GameObject targetBody;
    public GameObject bullet;
    private int speed = 600;
    private float waitTime = 0.4f;
    private bool canShoot = true;
    private float fieldOfView = 10f;
    public TextMesh enemyHealthText;
    public GameObject bulletSpawn;

    private void Start()
    {
        enemyHealthText = gameObject.GetComponentInChildren<TextMesh>();
        bulletSpawn = transform.GetChild(2).gameObject;
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, targetBody.transform.position - bulletSpawn.transform.position, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Ground")
            {
                enemyHealthText.gameObject.SetActive(false);
            }
            else
            {
                enemyHealthText.gameObject.SetActive(true);
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
                if (angle < fieldOfView)
                {
                    if (canShoot) { StartCoroutine(Shoot()); }
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        GameObject instBullet = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation) as GameObject;

        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddForce(transform.forward * speed);
        Destroy(instBullet, 5f);
        canShoot = false;
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
