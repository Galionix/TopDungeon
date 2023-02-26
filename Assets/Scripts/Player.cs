using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: Mover
{
    private void FixedUpdate()
    {
        // Get input
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        UpdateMotor(input);
    }
}
