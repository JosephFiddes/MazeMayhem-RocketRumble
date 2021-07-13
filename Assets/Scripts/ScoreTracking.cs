using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreTracking : MonoBehaviour
{
    [Range(1f, 100f)]
    public float score_freq = 10f;
    //public Text score_text;
    
    public long pot_score = 0;
    public long max_in_pot = 50;
    public long bank = 0;
    private float init_time;

    // Start is called before the first frame update
    void Start()
    {
        init_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        pot_score = Math.Min((long)((Time.time - init_time) * score_freq), max_in_pot);

        //score_text.text = "Score: " + bank.ToString() +"\n(" + pot_score.ToString() + ")"; 
    }

    // Called when the player hits the score thing.
    public void CollectBank()
    {
        bank += pot_score;
        init_time = Time.time;
    }
}
