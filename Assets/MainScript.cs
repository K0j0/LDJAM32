using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
    public Hero hero;
    public Camera cam;
    float camLeftBound = 0;
    float camRightBound = 10;
    float heroTopBounds = 0;
    float heroBottomBounds = -3.6f;
    float heroFeetTopBounds = -.5f; //0
    float heroFeetBottomBounds = -4.5f; //-3.6

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //print("Hero moving? " + hero.isMoving + " xPos: " + hero.transform.localPosition.x);
        if (hero.isMoving)
        {
            checkCameraBounds();
            checkHeroBounds();
        }
	}

    void checkCameraBounds()
    {
        Vector3 oldPos = cam.transform.localPosition;
        if (hero.transform.localPosition.x < camLeftBound)
        {
            cam.transform.localPosition = new Vector3(0, oldPos.y, oldPos.z);
        }
        else if (hero.transform.localPosition.x > camRightBound)
        {
            cam.transform.localPosition = new Vector3(camRightBound, oldPos.y, oldPos.z);
        }
        else
        {
            cam.transform.localPosition = new Vector3(hero.transform.localPosition.x, oldPos.y, oldPos.z);
        }
    }

    void checkHeroBounds()
    {
        if (hero.isMoving)
        {
            print(hero.feet.transform.position + " - " + hero.transform.localPosition);
            Vector3 oldPos = hero.transform.localPosition;
            if (hero.feet.position.y > heroFeetTopBounds)
            {
                hero.transform.localPosition = new Vector3(oldPos.x, heroTopBounds, oldPos.z);
            }
            else if (hero.feet.position.y < heroFeetBottomBounds)
            {
                hero.transform.localPosition = new Vector3(oldPos.x, heroBottomBounds, oldPos.z);
            }
        }
    }
}
