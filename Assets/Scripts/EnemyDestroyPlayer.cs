using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyPlayer : MonoBehaviour
{
    private ExitScene exit;
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D other)
    {
        // There must be an explosion.
        if (explosion)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        }

        if (other.collider.tag == "Player")
        {
            // Player's been hit.
            Destroy(other.collider.gameObject);

            exit = GameObject.Find("Exit Scene").GetComponent<ExitScene>(); ;
            exit.WrapItUp();

            //SceneManager.LoadScene("GameOver");

        }
        else
        {
            print("Enemy hit wall??");
            Destroy(gameObject);
        }
    }
}
