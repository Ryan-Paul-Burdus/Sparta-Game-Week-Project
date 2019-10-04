# Sparta-Game-Week-Project 
### Created by Ryan Burdus, 16/09/2019
 Game made in the game week of training at Sparta Global. 
 This game is a first person puzzle game created in Unity with C# where the main features of the game are:
 - platforms that change your players color to the platforms color on collision. 
 - player can only stand on platforms which are the same color as themselves
 - to traverse a maze to find and collect a key to then be able to exit through a specific door found within the maze.
 
 The player will be able to pick up certain items such as coins, ammo, and health throughout the game and will have multiple different guns to help eliminate enemies that are found throughout certain levels. There are multiple levels for the game at this stage and each has its own level design.
 
 All code and models used within this game have been created by myself (Ryan Burdus) and nobody else.
 
## Code Highlights 

- AI turret Tracking 
```C#
RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, targetBody.transform.position - bulletSpawn.transform.position, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Ground")
            {
                lookAtRotation = Quaternion.Euler(0f, lookOrigin, 0f);// LookRotation(Vector3.forward, Vector3.up);

                if (transform.rotation != lookAtRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                }
            }
            else
            {
                if (target)
                {
                    if (lastKnownPosition != target.transform.position)
                    {
                        lastKnownPosition = target.transform.position;
                        lookAtRotation = Quaternion.LookRotation(lastKnownPosition - transform.position, Vector3.up);
                    }
                    if (transform.rotation != lookAtRotation)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                    }
                }
            }
        }
```

- Color changing feature
```C#
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
            foreach (GameObject platform in platforms)
            {

                if (this.GetComponent<MeshRenderer>().material.name.Contains(platform.GetComponent<MeshRenderer>().material.name))
                {
                    platform.GetComponent<BoxCollider>().enabled = true;
                }
                else
                {
                    platform.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }
```

- Code based moving platforms
```C#
if (lastOnPos1) { transform.position = Vector3.MoveTowards(transform.position, position2.transform.position, speed * Time.deltaTime); }
        else { transform.position = Vector3.MoveTowards(transform.position, position1.transform.position, speed * Time.deltaTime); }
```

- Shooting 
```C#
IEnumerator Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, playerCamera.transform.rotation) as GameObject;
        this.currentAmmo--;
        ammoText.text = "Ammo = " + this.currentAmmo + "/" + this.totalAmmo;
        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddForce(playerCamera.transform.forward * speed);
        Destroy(instBullet, 5f);
        canShoot = false;
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
```
 
## How to run the game
 - To run the program you will need to have Unity 2019.2.3f1 installed on your computer and to load up the project once this is finished.

- To run the game as a build you will need to build the game within Unity and run the .exe that is then downloaded from that. This is only because I am yet to make a build for this game at this time.
 
## Screenshots

- Color changing platforms
 
![alt text](https://github.com/Ryan-Paul-Burdus/Sparta-Game-Week-Project/blob/master/Screenshots/Blue%20platform.png "Blue platform")
![alt text](https://github.com/Ryan-Paul-Burdus/Sparta-Game-Week-Project/blob/master/Screenshots/Red%20platform.png "Red platform")

- AI enemy turret
 
![alt text](https://github.com/Ryan-Paul-Burdus/Sparta-Game-Week-Project/blob/master/Screenshots/AI%20turret.png "AI turret")

- Pick-ups
 
![alt text](https://github.com/Ryan-Paul-Burdus/Sparta-Game-Week-Project/blob/master/Screenshots/Ammo%20and%20health.png "Ammo and health")
![alt text](https://github.com/Ryan-Paul-Burdus/Sparta-Game-Week-Project/blob/master/Screenshots/Key.png "Key")
