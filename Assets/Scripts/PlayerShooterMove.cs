using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterMove : MonoBehaviour
{
    //[Range(0.0f, 1.0f)]
    public float speed = 1.0f;
    //[Range(0.0f, 1.0f)]
    //public float friction = 0.05f;

    public Rigidbody2D body;

    private InputGrabber inputGrabber;

    //private Vector3 vel = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        inputGrabber = gameObject.GetComponent<InputGrabber>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Ydir_in != 0.0f)
        {
            gameObject.transform.position += new Vector3(0, speed * Ydir_in, 0) * Time.deltaTime;
        }

        if (Xdir_in != 0.0f)
        {
            gameObject.transform.position += new Vector3(speed * Xdir_in, 0, 0) * Time.deltaTime;
        }*/

        /*Vector3 accel = inputGrabber.inputMovement() * speed;

        vel += accel - vel*friction;

        gameObject.transform.position += vel * Time.deltaTime;*/

    }

    void FixedUpdate()
    {
        body.AddForce(inputGrabber.inputMovement() * speed);

    }
}
