using UnityEngine;
using System.Collections;
using System;

public class Hero : MonoBehaviour {
    public float speed = 5;
    float multiplier = 100;
    public SpriteRenderer sprite;
    public Animator anim;
    bool pressed;
    bool facingLeft;

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
        pressed = false;
        facingLeft = false;
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
            facingLeft = false;
            _isMoving = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //print("H-");
            currPos.x -= adjSpeed;
            facingLeft = true;
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
        anim.SetBool("walk", _isMoving);
        transform.localPosition = currPos;
        if (facingLeft)
        {
            if (transform.localScale.x > 0) transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x < 0) transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void handleInput()
    {
        if (!pressed)
        {
            if(Input.GetKey(KeyCode.Z)){
                pressed = true;
                print("Hi 5");
                anim.SetTrigger("doAction");
                EventManager.callHeroAction();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Z)){
            pressed = false;
            print("Release");
        }
    }

    void simpleZSort()
    {
        float sortPos = (10 - transform.localPosition.y) * 100;
        sprite.sortingOrder = Convert.ToInt16(sortPos);
    }
}
