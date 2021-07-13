using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputGrabber : MonoBehaviour
{
    public bool up()
    {
        return (Input.GetKey("w") || Input.GetKey("up"));
    }

    public bool down()
    {
        return (Input.GetKey("s") || Input.GetKey("down"));
    }

    public bool left()
    {
        return (Input.GetKey("a") || Input.GetKey("left"));
    }

    public bool right()
    {
        return (Input.GetKey("d") || Input.GetKey("right"));
    }

    public Vector3 inputMovement()
    {
        float Ydir_in = 0.0f;
        float Xdir_in = 0.0f;

        if (up()) Ydir_in += 1.0f;
        if (down()) Ydir_in -= 1.0f;
        if (right()) Xdir_in += 1.0f;
        if (left()) Xdir_in -= 1.0f;

        Vector3 inputVector = new Vector3(Xdir_in, Ydir_in, 0);
        inputVector.Normalize();
        return inputVector;
    }
}
