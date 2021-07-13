using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedText : MonoBehaviour
{
    public Text text1;
    public Text text2;
    private bool initial_pause = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //text1.text = "Start!";
        //text2.text = "Start!";
    }

    public void Pause()
    {
        if (initial_pause)
        {
            initial_pause = false;
        }
        else
        {
            text1.text = "Paused!";
            text2.text = "Paused!";
        }
    }
}
