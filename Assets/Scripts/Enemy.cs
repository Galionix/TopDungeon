using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLength = 1f;
    public float chaseLength = 5f;

    private bool chasing = false;
    private bool collidingWithPlayer = false;

    private Transform playerTransform;

    private Vector3 startingPosition;

    //  Hitbox
    public ContactFilter2D filter;

    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            chasing = Vector3.Distance(playerTransform.position, startingPosition) < triggerLength;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    Vector3 playerDirection = (
                        playerTransform.position - transform.position
                    ).normalized;
                    UpdateMotor(playerDirection);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        // Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        foreach (Collider2D coll in hits)
        {
            if (coll != null)
            {
                if (coll.tag == "Player")
                {
                    collidingWithPlayer = true;
                    break;
                }
            }
        }



    }


    protected override void Death(){

        // base.Death();
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.green, transform.position, Vector3.up * 25, 1.0f);
        Destroy(gameObject);
    }
}
