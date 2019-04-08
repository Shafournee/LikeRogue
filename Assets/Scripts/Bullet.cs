using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletLife = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletLife());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If this returns true we know there is a valid on hit function, in which case we don't want to destroy the bullet
        if(transform.parent.GetComponent<PlayerItems>().CallOnBulletHitFunctions(gameObject, collider.gameObject))
        {
            // But we still want to deal damage to enemies, and destroy it if it is an enemy
            if(collider.GetComponent<Enemy>())
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);

    }
}
