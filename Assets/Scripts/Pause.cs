using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused = false;
    public GameObject pause_screen;
    public PausedText pause_text;

    // Start is called before the first frame update
    void Start()
    {
        // This doesn't really have anything to do with pausing,
        // but the script is already here, I can't be bothered making
        // another one.
        Cursor.visible = false;

        DoThePause();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            if (Input.GetKeyDown("space") || Input.GetKeyDown("escape") ||
                Input.GetKeyDown("w") || Input.GetKeyDown("a") ||
                Input.GetKeyDown("s") || Input.GetKeyDown("d") ||
                Input.GetKeyDown("up") || Input.GetKeyDown("down") ||
                Input.GetKeyDown("left") || Input.GetKeyDown("right"))
            {
                DoTheUnpause();
            }
        } else if (Input.GetKeyDown("space") || Input.GetKeyDown("escape"))
        {
            DoThePause();
        }
    }

    void DoThePause()
    {
        Time.timeScale = 0;
        pause_text.Pause();
        pause_screen.SetActive(true);
        paused = true;
    }

    void DoTheUnpause()
    {
        Time.timeScale = 1;
        pause_screen.SetActive(false);
        paused = false;
    }
}
