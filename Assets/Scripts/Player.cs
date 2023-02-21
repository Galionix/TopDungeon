using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    private RaycastHit2D hitY;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // private void Awake()
    // {
    //     boxCollider = GetComponent<BoxCollider2D>();
    // }

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction
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
            transform.Translate(0,moveDelta.y * Time.deltaTime, 0);
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
