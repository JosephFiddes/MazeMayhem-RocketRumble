using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Range(1f, 10f)]
    public float speed = 5f;

    private Vector3 dir = new Vector3(0, 0, 0);

    private float survive_time = 20f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject target = GameObject.Find("Player Shooter");

        if (target)
        {
            dir = (target.transform.position - gameObject.transform.position);
            dir.Normalize();

            // Rotate the enemy to face the player.
            // This formula was found by trial and error.
            gameObject.transform.rotation = Quaternion.Euler(
                new Vector3(0f, 0f, -Vector3.SignedAngle(
                    dir, new Vector3(0, 1, 0), new Vector3(0, 0, 1))
                )
            );

            // The time which we keep the enemy is proportional to how long it's on screen.
            survive_time /= speed;
        } else
        {
            print("Enemy cannot choose direction because of missing player!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Move
        gameObject.transform.position += dir * speed * Time.deltaTime;

        // Destroy after a while.
        survive_time -= Time.deltaTime;

        if (survive_time < 0f)
        {
            Destroy(gameObject);
        }
    }


}
