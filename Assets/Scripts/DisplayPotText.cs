using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPotText : MonoBehaviour
{
    public Text textbox;
    public ScoreTracking scoreTracking;

    // Update is called once per frame
    void Update()
    {
        textbox.text = "";
        textbox.text = scoreTracking.pot_score.ToString();
    }
}
