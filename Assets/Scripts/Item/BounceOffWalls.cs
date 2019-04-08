using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffWalls : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool OnBulletHit(GameObject bullet, GameObject hit)
    {
        // If it's not an enemy we hit, we want to bounce off of it
        if(hit.GetComponent<Enemy>() == null)
        {
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            // Let's generate a newish angle for the ball
            bulletRB.velocity = new Vector2(-bulletRB.velocity.x, -bulletRB.velocity.y);
        }
        return true;
    }
}
