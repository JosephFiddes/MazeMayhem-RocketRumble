using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyColor : MonoBehaviour
{
    public Text original_text;
    public Text copy_text;

    // Update is called once per frame
    void Update()
    {
        copy_text.color = original_text.color;
    }
}