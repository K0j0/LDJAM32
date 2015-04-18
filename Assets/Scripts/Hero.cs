using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
    public float speed = 5;
    float multiplier = 100;

    float adjSpeed
    {
        get
        {
            return speed / multiplier;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currPos = transform.localPosition;

	    // movement
        if (Input.GetAxis("Horizontal") > 0)
        {
            print("H+");
            currPos.x += adjSpeed;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            print("H-");
            currPos.x -= adjSpeed;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            print("V+");
            currPos.y += adjSpeed;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            print("V-");
            currPos.y -= adjSpeed;
        }
        transform.localPosition = currPos;
	}
}
