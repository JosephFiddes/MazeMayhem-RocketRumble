using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreBank : MonoBehaviour
{
    public GameObject scoreBank;

    List<Vector3> positions = new List<Vector3>();

    public GameObject right_cam;
    public float innyness = 1f;

    public GameObject l_player;
    public GameObject r_player;

    public float minimum_distance = 100f;

    private Camera subcam;

    private float xLo;
    private float xHi;
    private float yLo;
    private float yHi;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            //child is your child transform
            positions.Add(child.transform.position);
        }

        // Get camera bounds.
        subcam = right_cam.GetComponent<Camera>();

        yHi = right_cam.transform.position.y + subcam.orthographicSize;
        xHi = right_cam.transform.position.x + subcam.orthographicSize * subcam.aspect;

        yLo = right_cam.transform.position.y - subcam.orthographicSize;
        xLo = right_cam.transform.position.x - subcam.orthographicSize * subcam.aspect;

        PlaceScoreBank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceScoreBank()
    {

        Vector3 new_pos;

        // Choose whether to put the thing on the left or right side.
        int left_side = UnityEngine.Random.Range(0, 2);

        int counter = 0;
        new_pos = GetPosition(left_side);

        while (PlayerTooClose(new_pos))
        {
            new_pos = GetPosition(left_side);
            counter++;
            if (counter > 100)
            {
                print("Tried 100 times");
                break;
            }
        }

        Instantiate(scoreBank, new_pos, Quaternion.identity);
    } 

    private Vector3 GetPosition(int left_side)
    {
        if (left_side == 1)
        {
            return positions[UnityEngine.Random.Range(0, positions.Count)];
        }
        else
        { // Right side
            return new Vector3(UnityEngine.Random.Range(xLo + innyness, xHi - innyness),
                UnityEngine.Random.Range(yLo + innyness, yHi - innyness), 20f);
        }
    }

    private bool PlayerTooClose(Vector3 pos)
    {
        Vector3 l_pos = l_player.transform.position;
        Vector3 r_pos = r_player.transform.position;

        print(l_pos);
        print(r_pos);
        print(pos);

        float dist_sqr = Math.Min(xyMagnitude_nosqrt((l_pos - pos)), xyMagnitude_nosqrt((r_pos - pos)));

        print(dist_sqr);

        if (dist_sqr < minimum_distance * minimum_distance)
        {
            print("Too close");
            return true;
        }

        return false;
    }

    private float xyMagnitude_nosqrt(Vector3 vec)
    {
        return vec.x * vec.x + vec.y * vec.y;
    }
}
