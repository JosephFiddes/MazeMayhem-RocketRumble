using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMazeMove : MonoBehaviour
{
    public float speed = 1.0f;
    private InputGrabber inputGrabber;

    public Rigidbody2D body;

    //private int Ydir_in = 0;
    //private int Xdir_in = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputGrabber = gameObject.GetComponent<InputGrabber>();
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.transform.position += inputGrabber.inputMovement() * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        body.AddForce(inputGrabber.inputMovement() * speed);
    }
}
