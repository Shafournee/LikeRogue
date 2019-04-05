using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    float bulletSpeed = 15f;

    bool isShooting;

    enum shootDir { up, down, left, right }

    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null)
            Debug.Log("No bullet attached!!");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShooting)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine(shootBullet(shootDir.up));
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine(shootBullet(shootDir.down));
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine(shootBullet(shootDir.left));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine(shootBullet(shootDir.right));
            }
        }
    }

    IEnumerator shootBullet(shootDir shootingDir)
    {
        isShooting = true;
        yield return new WaitForFixedUpdate();

        // Calculate the vector of the bullet based on the input direction
        // And the position relative to the player
        float spawnDisplacement = 1f;
        Vector2 bulletSpawnPos = new Vector2();
        Vector2 bulletVel = new Vector2();
        switch (shootingDir)
        {
            case shootDir.up:
                bulletVel = new Vector2(0f, 1f);
                bulletSpawnPos = new Vector2(0f, spawnDisplacement);
                break;
            case shootDir.down:
                bulletVel = new Vector2(0f, -1f);
                bulletSpawnPos = new Vector2(0f, -spawnDisplacement);
                break;
            case shootDir.right:
                bulletVel = new Vector2(1f, 0f);
                bulletSpawnPos = new Vector2(spawnDisplacement, 0f);
                break;
            case shootDir.left:
                bulletVel = new Vector2(-1f, 0f);
                bulletSpawnPos = new Vector2(-spawnDisplacement, 0f);
                break;
        }

        // TODO: add the players movement to modify the bullet speed

        // Now let's instantiate the bullet
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        GameObject newBullet = Instantiate(bullet, pos + bulletSpawnPos, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = bulletVel * bulletSpeed;


        // Wait for the player to be able to shoot the next bullet
        yield return new WaitForSeconds(.1f);
        isShooting = false;
    }
}
