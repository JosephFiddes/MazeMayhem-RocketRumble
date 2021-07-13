using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCameraColour : MonoBehaviour
{
    public SpriteRenderer player_share;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = gameObject.GetComponent<Camera>();

        Color colour = GenerateColour();
        cam.backgroundColor = colour;

        player_share.color = colour;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    Color GenerateColour()
    {
        // Create a beautiful, light colour.
        float h = Random.Range(0.0f, 1.0f);
        float s = 0.24f;
        float v = 1f;

        return Color.HSVToRGB(h, s, v);
    }
}
