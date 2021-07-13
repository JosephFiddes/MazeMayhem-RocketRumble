using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public ScoreTracking scores;
    public Camera cam1;
    public Camera cam2;
    
    public void WrapItUp()
    {
        Globals.final_score = scores.bank;
        Globals.color1 = cam1.backgroundColor;
        Globals.color2 = cam2.backgroundColor;
        SceneManager.LoadScene("GameOver");
    }
}
