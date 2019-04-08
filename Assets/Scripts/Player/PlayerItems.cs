using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
    }

    public bool CallOnBulletHitFunctions(GameObject bullet, GameObject hit)
    {
        bool returnValue = false;
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].OnBulletHit(bullet, hit))
            {
                returnValue = true;
            }
        }

        return returnValue;
    }
}
