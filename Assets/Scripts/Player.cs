using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

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

        // Move
        // transform.position += moveDelta * Time.deltaTime * 5;
        transform.Translate(moveDelta * Time.deltaTime * 5, Space.World);
    }
}
