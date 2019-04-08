using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    string name;
    Sprite image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // What stats change when items are picked up
    public virtual void PickupEffect()
    {

    }

    // What stats change when items are lost
    public virtual void RemoveEffect()
    {

    }

    // What changes when a bullet is fired
    public virtual void OnBulletFired()
    {

    }

    // What changes when a bullet hits an enemy returns true if an enemy is hit
    public virtual bool OnBulletHit(GameObject bullet, GameObject hit)
    {
        return false;
    }

    // What changes when the player gets hit
    public virtual void OnPlayerHit()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<PlayerItems>() != null)
        {
            collider.GetComponent<PlayerItems>().AddItem(this);
            Destroy(gameObject);
        }
    }
}
