using UnityEngine;
using System.Collections;
using System;

public class Hero : MonoBehaviour {
    public float speed = 5;
    float multiplier = 100;
    public Transform feet;
    SpriteRenderer sprite;
    Animator anim;

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
    

	// Use this for initialization
	void Start () {
        _isMoving = false;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        hanldeMovement();
        handleInput();
        simpleZSort();
	}

    void hanldeMovement()
    {
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
    }

    void handleInput()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            print("Hi 5");
            anim.SetTrigger("doAction");
        }
    }

    void simpleZSort()
    {
        float sortPos = (10 - transform.localPosition.y) * 100;
        sprite.sortingOrder = Convert.ToInt16(sortPos);
    }
}
