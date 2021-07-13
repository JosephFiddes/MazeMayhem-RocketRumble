using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictWithinCamera : MonoBehaviour
{

    public GameObject cam;

    private Camera subcam;
    private CircleCollider2D playerEdge;

    private float xLo;
    private float xHi;
    private float yLo;
    private float yHi;

    // Start is called before the first frame update
    void Start()
    {
        // Get camera bounds.
        subcam = cam.GetComponent<Camera>();

        yHi = cam.transform.position.y + subcam.orthographicSize;
        xHi = cam.transform.position.x + subcam.orthographicSize * subcam.aspect;

        yLo = cam.transform.position.y - subcam.orthographicSize;
        xLo = cam.transform.position.x - subcam.orthographicSize * subcam.aspect;

        // Get the edge of the player.
        playerEdge = gameObject.GetComponent<CircleCollider2D>();

        // Move invisible walls in a bit.
        xLo += playerEdge.radius * gameObject.transform.localScale.x;
        xHi -= playerEdge.radius * gameObject.transform.localScale.x;

        yLo += playerEdge.radius * gameObject.transform.localScale.y;
        yHi -= playerEdge.radius * gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < xLo)
        {
            gameObject.transform.position = new Vector3(xLo, gameObject.transform.position.y, gameObject.transform.position.z);
        }
            
        if (gameObject.transform.position.x > xHi)
        {
            gameObject.transform.position = new Vector3(xHi, gameObject.transform.position.y, gameObject.transform.position.z);
        } 
            
        if (gameObject.transform.position.y < yLo)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yLo, gameObject.transform.position.z);
        }
            
        if (gameObject.transform.position.y > yHi)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yHi, gameObject.transform.position.z);
        }
    }

    /*
    void OnDrawGizmos()
    {
        Start();

        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector3(xHi, yHi, 0), new Vector3(xHi, yLo, 0));
        Gizmos.DrawLine(new Vector3(xHi, yLo, 0), new Vector3(xLo, yLo, 0));
        Gizmos.DrawLine(new Vector3(xLo, yLo, 0), new Vector3(xLo, yHi, 0));
        Gizmos.DrawLine(new Vector3(xLo, yHi, 0), new Vector3(xHi, yHi, 0));
    }
    */
}
