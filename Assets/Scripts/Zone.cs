using UnityEngine;
using System.Collections;

public class Zone {

    public Rect camBounds;
    public Rect heroBounds;


    public Zone(Rect _heroBounds, Rect _camBounds)
    {
        this.heroBounds = _heroBounds;
        this.camBounds = _camBounds;

        Vector3 leftSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 middle = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 0, 0));

        float xDiff = middle.x - leftSide.x;

        this.camBounds.xMin = _heroBounds.xMin + xDiff;
        this.camBounds.xMax = _heroBounds.xMax - xDiff;

        //Debug.Log("LS " + leftSide);
        //Debug.Log("M " + middle);
    }
}
