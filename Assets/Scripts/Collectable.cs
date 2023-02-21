using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collideable
{
    protected bool collected = false;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && !collected)
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
        Debug.Log("Collect");
    }
}
