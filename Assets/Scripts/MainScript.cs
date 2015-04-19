using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
    public Hero hero;
    public Camera cam;

	// Use this for initialization
	void Start () {
	    // make zones
        Rect heroBounds = new Rect();
        heroBounds.xMin = -6.7f;
        heroBounds.xMax = 6.7f * 2;
        heroBounds.yMin = -4.5f;
        heroBounds.yMax = -.67f;

        Rect camBounds = new Rect();
        GameData.instance.currentZone = new Zone(heroBounds, camBounds);
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
        if (hero.transform.localPosition.x < GameData.instance.currentZone.camBounds.xMin)
        {
            cam.transform.localPosition = new Vector3(GameData.instance.currentZone.camBounds.xMin, oldPos.y, oldPos.z);
        }
        else if (hero.transform.localPosition.x > GameData.instance.currentZone.camBounds.xMax)
        {
            cam.transform.localPosition = new Vector3(GameData.instance.currentZone.camBounds.xMax, oldPos.y, oldPos.z);
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
            //print(hero.feet.transform.position + " - " + hero.transform.localPosition);
            Vector3 oldPos = hero.transform.localPosition;
            // vertical bounds
            if (hero.transform.position.y > GameData.instance.currentZone.heroBounds.yMax)
            {
                oldPos.y = GameData.instance.currentZone.heroBounds.yMax;
                //hero.transform.localPosition = new Vector3(oldPos.x, GameData.instance.currentZone.heroBounds.yMax, oldPos.z);
            }
            else if (hero.transform.position.y < GameData.instance.currentZone.heroBounds.yMin)
            {
                oldPos.y = GameData.instance.currentZone.heroBounds.yMin;
                //hero.transform.localPosition = new Vector3(oldPos.x, GameData.instance.currentZone.heroBounds.yMin, oldPos.z);
            }

            // horizontal bounds
            if (hero.transform.position.x > GameData.instance.currentZone.heroBounds.xMax)
            {
                oldPos.x = GameData.instance.currentZone.heroBounds.xMax;
                //hero.transform.localPosition = new Vector3(GameData.instance.currentZone.heroBounds.xMax, oldPos.y, oldPos.z);
            }
            else if (hero.transform.position.x < GameData.instance.currentZone.heroBounds.xMin)
            {
                oldPos.x = GameData.instance.currentZone.heroBounds.xMin;
                //hero.transform.localPosition = new Vector3(GameData.instance.currentZone.heroBounds.yMin, oldPos.y, oldPos.z);
            }
            hero.transform.localPosition = oldPos;
        }
    }
}
