using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollect : MonoBehaviour
{

    GameObject scoreBankController;

    // Start is called before the first frame update
    void Start()
    {
        scoreBankController = GameObject.Find("Score Bank Controller");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Score token has been collected.
        if (other.gameObject.tag == "Player")
        {
            scoreBankController.GetComponent<ScoreBank>().PlaceScoreBank();
            scoreBankController.GetComponent<ScoreTracking>().CollectBank();
            Destroy(gameObject);
        };
    }
}
