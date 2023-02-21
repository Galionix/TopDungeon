using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emtpyChest;
    public int pesosAmount = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if (!collected)
        {
            base.OnCollect();
            GameManager.instance.pesos += pesosAmount;
            GetComponent<SpriteRenderer>().sprite = emtpyChest;
        }
    }
}
