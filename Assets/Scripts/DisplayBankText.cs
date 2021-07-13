using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBankText : MonoBehaviour
{
    public Text textbox;
    public ScoreTracking scoreTracking;

    // Update is called once per frame
    void Update()
    {
        long num = scoreTracking.bank;
        textbox.text = "";
        textbox.text = num.ToString();
    }
}
