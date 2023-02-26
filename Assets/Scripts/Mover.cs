using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;

    protected RaycastHit2D hitY;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // private void FixedUpdate()
    // {

    // }

    /// <summary>
    /// If the player is not colliding with anything, move the player
    /// </summary>
    /// <param name="Vector3">input</param>
    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // define hit
        hitY = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0f,
            new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking")
        );

        if (hitY.collider == null)
        {
            // Move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // define hit for x
        RaycastHit2D hitX = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0f,
            new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking")
        );

        if (hitX.collider == null)
        {
            // Move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
