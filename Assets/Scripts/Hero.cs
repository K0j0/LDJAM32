using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
    public float speed = 5;
    float multiplier = 100;
    bool _isMoving;
    public bool isMoving
    {
        get
        {
            return _isMoving;
        }
    }

    float adjSpeed
    {
        get
        {
            return speed / multiplier;
        }
    }
    public Transform feet;
    Animator anim;

	// Use this for initialization
	void Start () {
        _isMoving = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currPos = transform.localPosition;
        _isMoving = false;

	    // movement
        if (Input.GetAxis("Horizontal") > 0)
        {
            //print("H+");
            currPos.x += adjSpeed;
            _isMoving = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //print("H-");
            currPos.x -= adjSpeed;
            _isMoving = true;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            //print("V+");
            currPos.y += adjSpeed;
            _isMoving = true;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            //print("V-");
            currPos.y -= adjSpeed;
            _isMoving = true;
        }
        transform.localPosition = currPos;

        if (Input.GetKeyUp(KeyCode.Z))
        {
            print("Hi 5");
            anim.SetTrigger("doAction");
        }
	}
}
