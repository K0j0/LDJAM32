using UnityEngine;
using System.Collections;
using System;

public class SadSack : MonoBehaviour {
    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        simpleZSort();
	}

    void simpleZSort()
    {
        float sortPos = (10 - transform.localPosition.y) * 100;
        sprite.sortingOrder = Convert.ToInt16(sortPos);
    }
}
